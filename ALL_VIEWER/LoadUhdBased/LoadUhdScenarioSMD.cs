using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewerBase;
using System.IO;
using OpenTK;
using JADERLINK_MODEL_VIEWER.src.Nodes;
using SHARED_UHD_BIN_TPL.EXTRACT;
using SHARED_SCENARIO_SMD.SCENARIO_EXTRACT;
using SimpleEndianBinaryIO;
using SHARED_UHD_SCENARIO_SMD.EXTRACT;

namespace LoadUhdBased.src
{
    public class LoadUhdScenarioSMD
    {
        public Action<TreatedModel> ExternalAddTreatedModel;

        private ModelGroup modelGroup;
        private ScenarioNodeGroup sng;
        private bool isPS4NS;
        private Endianness endianness;

        public LoadUhdScenarioSMD(ModelGroup modelGroup, ScenarioNodeGroup sng, bool isPS4NS, Endianness endianness)
        {
            this.modelGroup = modelGroup;
            this.sng = sng;
            this.isPS4NS = isPS4NS;
            this.endianness = endianness;
        }

        public void LoadScenario(string SmdPath)
        {
            FileInfo fileInfo = null;
            FileStream smdfile = null;

            Dictionary<int, UhdBIN> uhdBinDic = null;
            UhdTPL uhdTpl = null;
            SMDLine[] SmdLines = null;

            try
            {
                fileInfo = new FileInfo(SmdPath);
                smdfile = fileInfo.OpenRead();

                uint OffsetBinArr = 0;
                uint OffsetTplArr = 0;
                SmdLines = SmdExtract.Extract(smdfile, out _, out OffsetBinArr, out OffsetTplArr, endianness);

                Extract_BIN_Inside_SMD extract_BIN_Inside_SMD = new Extract_BIN_Inside_SMD();
                Extract_BIN_Content_UHD_ALT extract_BIN_Content = new Extract_BIN_Content_UHD_ALT(endianness, isPS4NS);
                extract_BIN_Inside_SMD.ToExtractBin = extract_BIN_Content.ToExtractBin;

                Extract_TPL_Content_UHD extract_TPL_Content = new Extract_TPL_Content_UHD(endianness, isPS4NS);
                Extract_TPL_Inside_SMD extract_TPL_Inside_SMD = new Extract_TPL_Inside_SMD_UHD();
                extract_TPL_Inside_SMD.ToExtractTpl = extract_TPL_Content.ToExtractTpl;

                int BinFilesCount = 0;
                int TplFilesCount = 0;
                CounterBinTpl.Calc(SmdLines, out BinFilesCount, out TplFilesCount);

                extract_BIN_Inside_SMD.ExtractBINs(smdfile, endianness, OffsetBinArr, BinFilesCount);
                extract_TPL_Inside_SMD.ExtractTPLs(smdfile, endianness, OffsetTplArr, TplFilesCount);

                uhdBinDic = extract_BIN_Content.BIN_DIC;
                if (extract_TPL_Content.UhdTplDic.ContainsKey(0))
                {
                    uhdTpl = extract_TPL_Content.UhdTplDic[0];
                }           
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error:");
            }
            finally 
            {
                smdfile?.Close();
            }

            if (fileInfo != null && SmdLines != null && SmdLines.Length != 0)
            {
                string Nodekey = "SCENARIOSMD";

                string ScenarioTPL = "SCENARIOTPL";

                var node = sng.Nodes.Find(Nodekey, false).FirstOrDefault();
                ((NodeItem)node)?.Responsibility.ReleaseResponsibilities();
                node?.Remove();

                string smdName = fileInfo.Name.ToUpperInvariant();
                SmdGroup smdGroup = new SmdGroup(smdName);

                for (int i = 0; i < SmdLines.Length; i++)
                {
                    SmdEntry entry = new SmdEntry();
                    entry.SMD_ID = i;
                    entry.BIN_ID = SmdLines[i].BinFileID;
                    entry.SMX_ID = SmdLines[i].SmxID;
                    PreFix fix = new PreFix();
                    fix.Angle = new Vector3(SmdLines[i].AngleX, SmdLines[i].AngleY, SmdLines[i].AngleZ);
                    fix.Position = new Vector3(SmdLines[i].PositionX / 100.0f, SmdLines[i].PositionY / 100.0f, SmdLines[i].PositionZ / 100.0f);
                    fix.Scale = new Vector3(SmdLines[i].ScaleX, SmdLines[i].ScaleY, SmdLines[i].ScaleZ);
                    entry.Fix = fix;
                    smdGroup.SmdEntries.Add(i, entry);
                }

                modelGroup.AddSmdGroup(smdGroup);

                ResponsibilityContainer RContainer = new ResponsibilityContainer();
                SMD_Representation smd_representation = new SMD_Representation(smdName);
                ScenarioSmdResponsibility smdResponsibility = new ScenarioSmdResponsibility(modelGroup, smd_representation);
                RContainer.Add(smdResponsibility);

                // TPL

                if (uhdTpl != null)
                {
                    MatTexGroup_Representation mat_representation = new MatTexGroup_Representation(ScenarioTPL);
                    MatTexGroupResponsibility matTexResponsibility = new MatTexGroupResponsibility(modelGroup, mat_representation);
                    RContainer.Add(matTexResponsibility);

                    MatTexGroup matTexGroup = new MatTexGroup(ScenarioTPL);

                    LoadUhdTpl.PopulateMatTexGroup(ref matTexGroup, ref uhdTpl);

                    modelGroup.AddMatTexGroup(matTexGroup);
                }

                //== bins
                if (uhdBinDic != null)
                {
                    foreach (var item in uhdBinDic)
                    {
                        var binkey = Nodekey + "_" + item.Key.ToString();

                        OBJ_Representation obj_representation = new OBJ_Representation(binkey);
                        ModelResponsibility modelResponsibility = new ModelResponsibility(modelGroup, obj_representation);
                        RContainer.Add(modelResponsibility);
                        MaterialGroup_Representation materialGroup_Representation = new MaterialGroup_Representation(binkey);
                        MaterialGroupResponsibility materialGroupResponsibility = new MaterialGroupResponsibility(modelGroup, materialGroup_Representation);
                        RContainer.Add(materialGroupResponsibility);

                        MatLinker matLinker = new MatLinker(binkey, ScenarioTPL);
                        MaterialGroup materialGroup = new MaterialGroup(binkey);

                        TreatedModel treatedModel = new TreatedModel(binkey);
                        treatedModel.BIN_ID = item.Key;

                        var uhdBin = item.Value;

                        //adicina as vertices
                        LoadUhdBinModel.PopulateTreatedModel(ref treatedModel, ref uhdBin, binkey);

                        //materialGroup
                        LoadUhdBinModel.PopulateMaterialGroup(ref materialGroup, ref uhdBin);

                        // calculo Boundary do objeto.
                        BoundaryCalculation.TreatedModel(ref treatedModel);

                        //armazena o modelo em local externo
                        ExternalAddTreatedModel?.Invoke(treatedModel);

                        //------------------
                        // adicionar o modelo para renderização
                        modelGroup.AddModel(treatedModel);
                        modelGroup.AddMaterialGroup(materialGroup);
                        modelGroup.MatLinkerDic[binkey] = matLinker;
                    }


                }

                NodeScenario nodeScenario = new NodeScenario();
                nodeScenario.Name = Nodekey;
                nodeScenario.Text = smdName + " | Scenario SMD";
                nodeScenario.Responsibility = RContainer;
                sng.Nodes.Add(nodeScenario);
            }


        }

        private class Extract_BIN_Content_UHD_ALT
        {
            public Dictionary<int, UhdBIN> BIN_DIC { get; private set; }

            private Endianness _endianness;
            private bool _isPS4NS;

            public Extract_BIN_Content_UHD_ALT(Endianness endianness, bool isPS4NS)
            {
                _endianness = endianness;
                _isPS4NS = isPS4NS;
                BIN_DIC = new Dictionary<int, UhdBIN>();
            }

            public long ToExtractBin(int BinID, Stream fileStream, long StartOffset)
            {
                long endOffset = StartOffset;
                if (StartOffset > 0)
                {
                    try
                    {
                        var uhdBin = UhdBinDecoder.Decoder(fileStream, StartOffset, out endOffset, _isPS4NS, _endianness);
                        BIN_DIC.Add(BinID, uhdBin);
                    }
                    catch (Exception)
                    {
                    }
                }

                return endOffset;
            }
        }
    }
}
