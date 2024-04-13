using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using ViewerBase;
using System.IO;
using OpenTK;
using JADERLINK_MODEL_VIEWER.src.Nodes;
using JADERLINK_MODEL_VIEWER.src.Structures;

namespace JADERLINK_MODEL_VIEWER.src
{
    public class LoadOBJ
    {
        private ModelGroup modelGroup;
        private ModelNodeGroup mng;

        public LoadOBJ(ModelGroup modelGroup, ModelNodeGroup mng)
        {
            this.modelGroup = modelGroup;
            this.mng = mng;
        }

        public void Load(string Path, bool SplitGroups)
        {

            FileInfo fileInfo = new FileInfo(Path);
            string FileID = fileInfo.Name.ToUpperInvariant();
            string FileName = fileInfo.Name;


            var nodes = mng.Nodes.Find(FileID, false);
            foreach (var node in nodes)
            {
                ((NodeItem)node)?.Responsibility.ReleaseResponsibilities();
                node?.Remove();
            }

            if (!modelGroup.Objects.ContainsKey(FileID))
            {
                ObjLoader.Loader.Loaders.LoadResult arqObj = null;
                StreamReader streamReader = null;

                try
                {
                    // load .obj file
                    var objLoaderFactory = new ObjLoader.Loader.Loaders.ObjLoaderFactory();
                    var objLoader = objLoaderFactory.Create();
                    streamReader = new StreamReader(Path, Encoding.ASCII);
                    arqObj = objLoader.Load(streamReader);
                    streamReader.Close();
                }
                catch (Exception)
                {
                    if (streamReader != null)
                    {
                        streamReader.Close();
                    }
                }

                if (arqObj != null)
                {
                    Dictionary<string, StartStructure> ObjList = new Dictionary<string, StartStructure>();

                    try { PopulateStartStructure(ref ObjList, ref arqObj, SplitGroups); } catch (Exception) {}
                  
                    if (SplitGroups == false) // one group
                    {
                        StartStructure startStructure = ObjList[""];

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
                    else  // varios
                    {
                        string[] GroupNames = ObjList.Keys.OrderByDescending(x => x).ToArray();

                        for (int i = 0; i < GroupNames.Length; i++)
                        {
                            string key = FileID + "_" + GroupNames[i];

                            StartStructure startStructure = ObjList[GroupNames[i]];

                            //-------------------
                            ResponsibilityContainer RContainer = new ResponsibilityContainer();
                            OBJ_Representation obj_representation = new OBJ_Representation(key);
                            ModelResponsibility modelResponsibility = new ModelResponsibility(modelGroup, obj_representation);
                            RContainer.Add(modelResponsibility);

                            //--------
                            MatLinker matLinker = new MatLinker(key, FileID);

                            TreatedModel treatedModel = new TreatedModel(key);
                            treatedModel.BIN_ID = -1;

                            //etapa1
                            LoadModel.PopulateTreatedModel(ref treatedModel, ref startStructure, key);
                            //etapa 2
                            LoadModel.BoundaryCalculationTreatedModel(ref treatedModel);

                            //------------------
                            // adicionar o modelo para renderização
                            modelGroup.AddModel(treatedModel);
                            modelGroup.MatLinkerDic[key] = matLinker;

                            //node
                            NodeModel nodeModel = new NodeModel();
                            nodeModel.Name = FileID;
                            nodeModel.SetFileID(key);
                            nodeModel.SetBlockModelHiding(false);
                            nodeModel.Text = FileName + " | " + GroupNames[i];
                            nodeModel.Responsibility = RContainer;
                            mng.Nodes.Add(nodeModel);

                        }

                    }

                }


            }




        }



        private void PopulateStartStructure(ref Dictionary<string, StartStructure> ObjList, ref ObjLoader.Loader.Loaders.LoadResult arqObj, bool SplitGroups)
        {
            StartStructure OneStructure = null;
            if (SplitGroups == false)
            {
                OneStructure = new StartStructure();
                ObjList.Add("", OneStructure);
            }

            StartWeightMap weightMap = new StartWeightMap(1, 0, 1, 0, 0, 0, 0);

            for (int iG = 0; iG < arqObj.Groups.Count; iG++)
            {
                string GroupName = arqObj.Groups[iG].GroupName.ToUpperInvariant().Trim();

                string materialNameInvariant = arqObj.Groups[iG].MaterialName.ToUpperInvariant().Trim();

                List<List<StartVertex>> facesList = new List<List<StartVertex>>();

                for (int iF = 0; iF < arqObj.Groups[iG].Faces.Count; iF++)
                {
                    List<StartVertex> verticeListInObjFace = new List<StartVertex>();

                    for (int iI = 0; iI < arqObj.Groups[iG].Faces[iF].Count; iI++)
                    {
                        StartVertex vertice = new StartVertex();

                        if (arqObj.Groups[iG].Faces[iF][iI].VertexIndex <= 0 || arqObj.Groups[iG].Faces[iF][iI].VertexIndex - 1 >= arqObj.Vertices.Count)
                        {
                            throw new ArgumentException("Vertex Position Index is invalid! Value: " + arqObj.Groups[iG].Faces[iF][iI].VertexIndex);
                        }

                        Vector3 position = new Vector3(
                            arqObj.Vertices[arqObj.Groups[iG].Faces[iF][iI].VertexIndex - 1].X,
                            arqObj.Vertices[arqObj.Groups[iG].Faces[iF][iI].VertexIndex - 1].Y,
                            arqObj.Vertices[arqObj.Groups[iG].Faces[iF][iI].VertexIndex - 1].Z
                            );

                        vertice.Position = position;


                        if (arqObj.Groups[iG].Faces[iF][iI].TextureIndex <= 0 || arqObj.Groups[iG].Faces[iF][iI].TextureIndex - 1 >= arqObj.Textures.Count)
                        {
                            vertice.Texture = new Vector2(0, 0);
                        }
                        else
                        {
                            Vector2 texture = new Vector2(
                            arqObj.Textures[arqObj.Groups[iG].Faces[iF][iI].TextureIndex - 1].U,
                            ((arqObj.Textures[arqObj.Groups[iG].Faces[iF][iI].TextureIndex - 1].V - 1) * -1)
                            );

                            vertice.Texture = texture;
                        }


                        if (arqObj.Groups[iG].Faces[iF][iI].NormalIndex <= 0 || arqObj.Groups[iG].Faces[iF][iI].NormalIndex - 1 >= arqObj.Normals.Count)
                        {
                            vertice.Normal = new Vector3(0, 0, 0);
                        }
                        else
                        {
                            float nx = arqObj.Normals[arqObj.Groups[iG].Faces[iF][iI].NormalIndex - 1].X;
                            float ny = arqObj.Normals[arqObj.Groups[iG].Faces[iF][iI].NormalIndex - 1].Y;
                            float nz = arqObj.Normals[arqObj.Groups[iG].Faces[iF][iI].NormalIndex - 1].Z;
                            float NORMAL_FIX = (float)Math.Sqrt((nx * nx) + (ny * ny) + (nz * nz));
                            NORMAL_FIX = (NORMAL_FIX == 0) ? 1 : NORMAL_FIX;
                            nx /= NORMAL_FIX;
                            ny /= NORMAL_FIX;
                            nz /= NORMAL_FIX;

                            vertice.Normal = new Vector3(nx, ny, nz);
                        }

                        vertice.WeightMap = weightMap;


                        Vector4 vColor = new Vector4(
                        arqObj.Vertices[arqObj.Groups[iG].Faces[iF][iI].VertexIndex - 1].R,
                        arqObj.Vertices[arqObj.Groups[iG].Faces[iF][iI].VertexIndex - 1].G,
                        arqObj.Vertices[arqObj.Groups[iG].Faces[iF][iI].VertexIndex - 1].B,
                        arqObj.Vertices[arqObj.Groups[iG].Faces[iF][iI].VertexIndex - 1].A
                        );

                        vertice.Color = vColor;

                        verticeListInObjFace.Add(vertice);

                    }

                    if (verticeListInObjFace.Count >= 3)
                    {
                        for (int i = 2; i < verticeListInObjFace.Count; i++)
                        {
                            List<StartVertex> face = new List<StartVertex>();
                            face.Add(verticeListInObjFace[0]);
                            face.Add(verticeListInObjFace[i - 1]);
                            face.Add(verticeListInObjFace[i]);
                            facesList.Add(face);
                        }
                    }

                }


                if (SplitGroups == true)
                {
                    if (ObjList.ContainsKey(GroupName))
                    {
                        if (ObjList[GroupName].FacesByMaterial.ContainsKey(materialNameInvariant))
                        {
                            ObjList[GroupName].FacesByMaterial[materialNameInvariant].Faces.AddRange(facesList);
                        }
                        else
                        {
                            ObjList[GroupName].FacesByMaterial.Add(materialNameInvariant, new StartFacesGroup(facesList));
                        }
                    }
                    else
                    {
                        StartStructure startStructure = new StartStructure(); ;
                        startStructure.FacesByMaterial.Add(materialNameInvariant, new StartFacesGroup(facesList));
                        ObjList.Add(GroupName, startStructure);
                    }

                }
                else
                {
                    if (OneStructure.FacesByMaterial.ContainsKey(materialNameInvariant))
                    {
                        OneStructure.FacesByMaterial[materialNameInvariant].Faces.AddRange(facesList);
                    }
                    else
                    {
                        OneStructure.FacesByMaterial.Add(materialNameInvariant, new StartFacesGroup(facesList));
                    }
                }
            }
        }




    }
}
