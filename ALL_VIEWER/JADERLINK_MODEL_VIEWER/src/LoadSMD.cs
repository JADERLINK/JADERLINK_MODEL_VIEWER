using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using OpenTK;
using ViewerBase;
using System.IO;
using JADERLINK_MODEL_VIEWER.src.Nodes;
using JADERLINK_MODEL_VIEWER.src.Structures;

namespace JADERLINK_MODEL_VIEWER.src
{
    public class LoadSMD
    {
        private ModelGroup modelGroup;
        private ModelNodeGroup mng;

        public LoadSMD(ModelGroup modelGroup, ModelNodeGroup mng)
        {
            this.modelGroup = modelGroup;
            this.mng = mng;
        }

        public void Load(string Path)
        {
            FileInfo fileInfo = new FileInfo(Path);
            string FileID = fileInfo.Name.ToUpperInvariant();
            string FileName = fileInfo.Name;

            if (modelGroup.Objects.ContainsKey(FileID))
            {
                var node = mng.Nodes.Find(FileID, false).FirstOrDefault();
                ((NodeItem)node)?.Responsibility.ReleaseResponsibilities();
                node?.Remove();
            }

            if (!modelGroup.Objects.ContainsKey(FileID))
            {
                SMD_READER_API.SMD smd = null;
                StreamReader stream = null;

                try
                {
                     stream = new StreamReader(Path, Encoding.ASCII);
                     smd = SMD_READER_API.SmdReader.Reader(stream);
                }
                catch (Exception)
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                }

                if (smd != null)
                {
                    StartStructure startStructure = new StartStructure();

                    PopulateStartStructure(ref startStructure, ref smd);
                 
                    //-------------------
                    ResponsibilityContainer RContainer = new ResponsibilityContainer();
                    OBJ_Representation obj_representation = new OBJ_Representation(FileID);
                    ModelResponsibility modelResponsibility = new ModelResponsibility(modelGroup, obj_representation);
                    RContainer.Add(modelResponsibility);

                    //--------
                    MatLinker matLinker = new MatLinker(FileID, FileID);

                    TreatedModel treatedModel = new TreatedModel(FileID);
                    treatedModel.BIN_ID = -1;

                    //etapa1
                    LoadModel.PopulateTreatedModel(ref treatedModel, ref startStructure, FileID);
                    //etapa 2
                    LoadModel.BoundaryCalculationTreatedModel(ref treatedModel);

                    //------------------
                    // adicionar o modelo para renderização
                    modelGroup.AddModel(treatedModel);
                    modelGroup.MatLinkerDic[FileID] = matLinker;

                    //node
                    NodeModel nodeModel = new NodeModel();
                    nodeModel.Name = FileID;
                    nodeModel.SetFileID(FileID);
                    nodeModel.SetBlockModelHiding(false);
                    nodeModel.Text = FileName;
                    nodeModel.Responsibility = RContainer;
                    mng.Nodes.Add(nodeModel);

                }

            }

        }

        private void PopulateStartStructure(ref StartStructure startStructure, ref SMD_READER_API.SMD smd)
        {
            Vector4 color = new Vector4(1, 1, 1, 1);

            for (int i = 0; i < smd.Triangles.Count; i++)
            {
                string materialNameInvariant = smd.Triangles[i].Material.ToUpperInvariant().Trim();

                List<StartVertex> verticeList = new List<StartVertex>();

                for (int t = 0; t < smd.Triangles[i].Vertexs.Count; t++)
                {

                    StartVertex vertice = new StartVertex();
                    vertice.Color = color;


                    Vector3 position = new Vector3(
                            smd.Triangles[i].Vertexs[t].PosX,
                            smd.Triangles[i].Vertexs[t].PosZ,
                            smd.Triangles[i].Vertexs[t].PosY * -1
                            );

                    vertice.Position = position;

                    float nx = smd.Triangles[i].Vertexs[t].NormX;
                    float ny = smd.Triangles[i].Vertexs[t].NormZ;
                    float nz = smd.Triangles[i].Vertexs[t].NormY * -1;
                    float NORMAL_FIX = (float)Math.Sqrt((nx * nx) + (ny * ny) + (nz * nz));
                    NORMAL_FIX = (NORMAL_FIX == 0) ? 1 : NORMAL_FIX;
                    nx /= NORMAL_FIX;
                    ny /= NORMAL_FIX;
                    nz /= NORMAL_FIX;

                    vertice.Normal = new Vector3(nx, ny, nz);

                    Vector2 texture = new Vector2(
                    smd.Triangles[i].Vertexs[t].U,
                    ((smd.Triangles[i].Vertexs[t].V - 1) * -1)
                    );

                    vertice.Texture = texture;

                    //cria o objetos com os weight
                    // e corrige a soma total para dar 1

                    if (smd.Triangles[i].Vertexs[t].Links.Count == 0)
                    {
                        StartWeightMap weightMap = new StartWeightMap();
                        weightMap.Links = 1;
                        weightMap.BoneID1 = smd.Triangles[i].Vertexs[t].ParentBone;
                        weightMap.Weight1 = 1f;

                        vertice.WeightMap = weightMap;
                    }
                    else
                    {
                        StartWeightMap weightMap = new StartWeightMap();

                        var links = (from link in smd.Triangles[i].Vertexs[t].Links
                                     orderby link.Weight
                                     select link).ToArray();

                        if (links.Length >= 1)
                        {
                            weightMap.Links = 1;
                            weightMap.BoneID1 = links[0].BoneID;
                            weightMap.Weight1 = links[0].Weight;
                        }
                        if (links.Length >= 2)
                        {
                            weightMap.Links = 2;
                            weightMap.BoneID2 = links[1].BoneID;
                            weightMap.Weight2 = links[1].Weight;
                        }
                        if (links.Length >= 3)
                        {
                            weightMap.Links = 3;
                            weightMap.BoneID3 = links[2].BoneID;
                            weightMap.Weight3 = links[2].Weight;
                        }

                        // verificação para soma total dar 1

                        float sum = weightMap.Weight1 + weightMap.Weight2 + weightMap.Weight3;

                        if (sum > 1  // se por algum motivo aleatorio ficar maior que 1
                            || sum < 1) // ou se caso for menor que 1
                        {
                            float difference = sum - 1; // se for maior diferença é positiva, e se for menor é positiva
                            float average = difference / weightMap.Links; // aqui mantem o sinal da operação

                            if (weightMap.Links >= 1)
                            {
                                weightMap.Weight1 -= average; // se for positivo tem que dimiuir,
                                                              // porem se for negativo tem que aumentar,
                                                              // porem menos com menos da mais, então esta certo.
                            }
                            if (weightMap.Links >= 2)
                            {
                                weightMap.Weight2 -= average;
                            }
                            if (weightMap.Links >= 3)
                            {
                                weightMap.Weight3 -= average;
                            }

                            //re verifica se ainda tem diferença
                            float newSum = weightMap.Weight1 + weightMap.Weight2 + weightMap.Weight3;
                            float newDifference = newSum - 1;

                            if (newDifference != 1)
                            {
                                weightMap.Weight1 -= newDifference;
                            }
                        }

                        vertice.WeightMap = weightMap;
                    }


                    verticeList.Add(vertice);

                }

                if (startStructure.FacesByMaterial.ContainsKey(materialNameInvariant))
                {
                    startStructure.FacesByMaterial[materialNameInvariant].Faces.Add(verticeList);
                }
                else // cria novo
                {
                    StartFacesGroup facesGroup = new StartFacesGroup();
                    facesGroup.Faces.Add(verticeList);
                    startStructure.FacesByMaterial.Add(materialNameInvariant, facesGroup);
                }

            }

        }

    }
}
