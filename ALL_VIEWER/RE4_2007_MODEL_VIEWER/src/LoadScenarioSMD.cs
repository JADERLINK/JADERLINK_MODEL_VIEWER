using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewerBase;
using System.IO;
using OpenTK;
using JADERLINK_MODEL_VIEWER.src.Nodes;
using SHARED_2007PS2_SCENARIO_SMD.SCENARIO_EXTRACT;

namespace RE4_2007_MODEL_VIEWER.src
{
    class LoadScenarioSMD
    {
        private ModelGroup modelGroup;
        private ScenarioNodeGroup sng;

        public LoadScenarioSMD(ModelGroup modelGroup, ScenarioNodeGroup sng)
        {
            this.modelGroup = modelGroup;
            this.sng = sng;
        }

        public void LoadScenario(string SmdPath)
        {
            FileInfo fileInfo = new FileInfo(SmdPath);
            Stream smdStream = null;

            SMDLine[] lines = new SMDLine[0];
            try
            {
                smdStream = fileInfo.OpenRead();
                lines = SmdExtract2007PS2.Extract(smdStream, out _, out _, out _);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error:");
            }
            finally 
            {
                smdStream?.Close();
            }

            if (lines.Length != 0)
            {
                string Nodekey = "SCENARIOSMD";

                var node = sng.Nodes.Find(Nodekey, false).FirstOrDefault();
                ((NodeItem)node)?.Responsibility.ReleaseResponsibilities();
                node?.Remove();

                string smdName = fileInfo.Name.ToUpperInvariant();
                SmdGroup smdGroup = new SmdGroup(smdName);

                for (int i = 0; i < lines.Length; i++)
                {
                    SmdEntry entry = new SmdEntry();
                    entry.SMD_ID = i;
                    entry.BIN_ID = i;
                    entry.SMX_ID = lines[i].SmxID;
                    PreFix fix = new PreFix();
                    fix.Angle = new Vector3(lines[i].AngleX, lines[i].AngleY, lines[i].AngleZ);
                    fix.Position = new Vector3(lines[i].PositionX / 100.0f, lines[i].PositionY / 100.0f, lines[i].PositionZ / 100.0f);
                    fix.Scale = new Vector3(10.0f);
                    entry.Fix = fix;
                    smdGroup.SmdEntries.Add(i, entry);
                }

                modelGroup.AddSmdGroup(smdGroup);

                ResponsibilityContainer RContainer = new ResponsibilityContainer();
                SMD_Representation smd_representation = new SMD_Representation(smdName);
                ScenarioSmdResponsibility smdResponsibility = new ScenarioSmdResponsibility(modelGroup, smd_representation);
                RContainer.Add(smdResponsibility);

                NodeScenario nodeScenario = new NodeScenario();
                nodeScenario.Name = Nodekey;
                nodeScenario.Text = smdName + " | Scenario SMD";
                nodeScenario.Responsibility = RContainer;
                sng.Nodes.Add(nodeScenario);
            }

        }



    }
}
