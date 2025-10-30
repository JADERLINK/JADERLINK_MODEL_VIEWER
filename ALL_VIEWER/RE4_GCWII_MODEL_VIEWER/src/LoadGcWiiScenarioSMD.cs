using JADERLINK_MODEL_VIEWER.src.Nodes;
using SimpleEndianBinaryIO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ViewerBase;
using SHARED_GCWII_BIN.EXTRACT;
using SHARED_SCENARIO_SMD.SCENARIO_EXTRACT;
using OpenTK;

namespace RE4_GCWII_MODEL_VIEWER.src
{
    public class LoadGcWiiScenarioSMD
    {
        public Action<TreatedModel> ExternalAddTreatedModel;

        private ModelGroup modelGroup;
        private ScenarioNodeGroup sng;

        public LoadGcWiiScenarioSMD(ModelGroup modelGroup, ScenarioNodeGroup sng)
        {
            this.modelGroup = modelGroup;
            this.sng = sng;
        }

        public void LoadScenario(string SmdPath)
        {
            FileInfo fileInfo = null;
            FileStream smdfile = null;

            Dictionary<int, GCWIIBIN> BinDic = null;
            SMDLine[] SmdLines = null;

            try
            {
                fileInfo = new FileInfo(SmdPath);
                smdfile = fileInfo.OpenRead();

                uint OffsetBinArr = 0;
                uint OffsetTplArr = 0;
                SmdLines = SmdExtract.Extract(smdfile, out _, out OffsetBinArr, out OffsetTplArr, Endianness.BigEndian);

                Extract_BIN_Inside_SMD extract_BIN_Inside_SMD = new Extract_BIN_Inside_SMD();
                Extract_BIN_Content_GCWII_ALT extract_BIN_Content = new Extract_BIN_Content_GCWII_ALT();
                extract_BIN_Inside_SMD.ToExtractBin = extract_BIN_Content.ToExtractBin;

                int BinFilesCount = 0;
                int TplFilesCount = 0;
                CounterBinTpl.Calc(SmdLines, out BinFilesCount, out TplFilesCount);

                extract_BIN_Inside_SMD.ExtractBINs(smdfile, Endianness.BigEndian, OffsetBinArr, BinFilesCount);

                BinDic = extract_BIN_Content.BIN_DIC;
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

                //== bins
                if (BinDic != null)
                {
                    foreach (var item in BinDic)
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
                        LoadGcWiiBinModel.PopulateTreatedModel(ref treatedModel, ref uhdBin, binkey);

                        //materialGroup
                        LoadGcWiiBinModel.PopulateMaterialGroup(ref materialGroup, ref uhdBin);

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

        private class Extract_BIN_Content_GCWII_ALT
        {
            public Dictionary<int, GCWIIBIN> BIN_DIC { get; private set; }

            public Extract_BIN_Content_GCWII_ALT()
            {
                BIN_DIC = new Dictionary<int, GCWIIBIN>();
            }

            public long ToExtractBin(int BinID, Stream fileStream, long StartOffset)
            {
                long endOffset = StartOffset;
                if (StartOffset > 0)
                {
                    try
                    {
                        var Bin = GcWiiBinDecoder.Decoder(fileStream, StartOffset, out endOffset);
                        BIN_DIC.Add(BinID, Bin);
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
