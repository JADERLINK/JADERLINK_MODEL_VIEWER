﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewerBase;
using System.IO;
using OpenTK;
using JADERLINK_MODEL_VIEWER.src.Nodes;
using RE4_UHD_BIN_TOOL.EXTRACT;
using RE4_UHD_BIN_TOOL.ALL;

namespace RE4_UHD_MODEL_VIEWER.src
{
    public class LoadUhdBinModel
    {
        private ModelGroup modelGroup;
        private ModelNodeGroup mng;

        public LoadUhdBinModel(ModelGroup modelGroup, ModelNodeGroup mng)
        {
            this.modelGroup = modelGroup;
            this.mng = mng;
        }

        public void LoadUhdBIN(string binPath)
        {
            FileInfo fileInfo = new FileInfo(binPath);
            string FileID = fileInfo.Name.ToUpperInvariant();

            if (modelGroup.Objects.ContainsKey(FileID))
            {
                var node = mng.Nodes.Find(FileID, false).FirstOrDefault();
                ((NodeItem)node)?.Responsibility.ReleaseResponsibilities();
                node?.Remove();
            }

            if (!modelGroup.Objects.ContainsKey(FileID))
            {
                UhdBIN uhdBIN = null;
                try
                {
                    Stream binFile = fileInfo.OpenRead();
                    uhdBIN = UhdBinDecoder.Decoder(binFile, 0, out _);
                    binFile.Close();
                }
                catch (Exception)
                {
                }

                if (uhdBIN != null)
                {

                    ResponsibilityContainer RContainer = new ResponsibilityContainer();
                    OBJ_Representation obj_representation = new OBJ_Representation(FileID);
                    ModelResponsibility modelResponsibility = new ModelResponsibility(modelGroup, obj_representation);
                    RContainer.Add(modelResponsibility);
                    MaterialGroup_Representation materialGroup_Representation = new MaterialGroup_Representation(FileID);
                    MaterialGroupResponsibility materialGroupResponsibility = new MaterialGroupResponsibility(modelGroup, materialGroup_Representation);
                    RContainer.Add(materialGroupResponsibility);

                    //--------
                    MatLinker matLinker = new MatLinker(FileID, FileID.Replace(".BIN", ".TPL"));
                    MaterialGroup materialGroup = new MaterialGroup(FileID);

                    TreatedModel treatedModel = new TreatedModel(FileID);
                    treatedModel.BIN_ID = -1;

                    //adicina as vertices
                    PopulateTreatedModel(ref treatedModel, ref uhdBIN, FileID);

                    //materialGroup
                    PopulateMaterialGroup(ref materialGroup, ref uhdBIN);

                    // calculo Boundary do objeto.
                    BoundaryCalculationTreatedModel(ref treatedModel);

                    //------------------
                    // adicionar o modelo para renderização
                    modelGroup.AddModel(treatedModel);
                    modelGroup.AddMaterialGroup(materialGroup);
                    modelGroup.MatLinkerDic[FileID] = matLinker;

                    //-------------------------

                    //node
                    NodeModel nodeModel = new NodeModel();
                    nodeModel.Name = FileID;
                    nodeModel.SetFileID(FileID);
                    nodeModel.SetBlockModelHiding(false);
                    nodeModel.Text = FileID;
                    nodeModel.Responsibility = RContainer;
                    mng.Nodes.Add(nodeModel);
                }

            }

        }

        public static void PopulateTreatedModel(ref TreatedModel treatedModel, ref UhdBIN uhdBIN, string FileID) 
        {
            int baseIndex = 0;
            int maxIndex = 0;
            //model
            for (int im = 0; im < uhdBIN.Materials.Length; im++)
            {
                Dictionary<Boundary, Vector3> boundary = new Dictionary<Boundary, Vector3>();

                uint[] indices = new uint[uhdBIN.Materials[im].face_index_array.Length * 3];

                int tempCont = 0;
                for (int i = 0; i < uhdBIN.Materials[im].face_index_array.Length; i++)
                {
                    indices[tempCont] = (uint)(uhdBIN.Materials[im].face_index_array[i].i1 - baseIndex);
                    indices[tempCont +1] = (uint)(uhdBIN.Materials[im].face_index_array[i].i2 - baseIndex);
                    indices[tempCont +2] = (uint)(uhdBIN.Materials[im].face_index_array[i].i3 - baseIndex);
                    tempCont += 3;

                    int tempI = uhdBIN.Materials[im].face_index_array[i].i1;
                    if (uhdBIN.Materials[im].face_index_array[i].i2 > tempI)
                    {
                        tempI = uhdBIN.Materials[im].face_index_array[i].i2;
                    }
                    if (uhdBIN.Materials[im].face_index_array[i].i3 > tempI)
                    {
                        tempI = uhdBIN.Materials[im].face_index_array[i].i3;
                    }

                    if (tempI > maxIndex)
                    {
                        maxIndex = tempI;
                    }
                }

                int count = maxIndex - baseIndex + 1;
                float[] vertices = new float[count * 12];

                int vOffset = 0;
                for (int i = baseIndex; i < maxIndex + 1; i++)
                {
                    var point = new Vector4(
                        uhdBIN.Vertex_Position_Array[i].vx / CONSTs.GLOBAL_POSITION_SCALE,
                        uhdBIN.Vertex_Position_Array[i].vy / CONSTs.GLOBAL_POSITION_SCALE,
                        uhdBIN.Vertex_Position_Array[i].vz / CONSTs.GLOBAL_POSITION_SCALE,
                        1);

                    vertices[vOffset + 0] = point.X;
                    vertices[vOffset + 1] = point.Y;
                    vertices[vOffset + 2] = point.Z;

                    float nx = uhdBIN.Vertex_Normal_Array[i].nx;
                    float ny = uhdBIN.Vertex_Normal_Array[i].ny;
                    float nz = uhdBIN.Vertex_Normal_Array[i].nz;

                    float NORMAL_FIX = (float)Math.Sqrt((nx * nx) + (ny * ny) + (nz * nz));
                    NORMAL_FIX = (NORMAL_FIX == 0) ? 1 : NORMAL_FIX;
                    nx /= NORMAL_FIX;
                    ny /= NORMAL_FIX;
                    nz /= NORMAL_FIX;

                    vertices[vOffset + 3] = nx;
                    vertices[vOffset + 4] = ny;
                    vertices[vOffset + 5] = nz;

                    vertices[vOffset + 6] = uhdBIN.Vertex_UV_Array[i].tu;
                    vertices[vOffset + 7] = uhdBIN.Vertex_UV_Array[i].tv;

                    if (uhdBIN.Header.ReturnsIsEnableVertexColors() && uhdBIN.Vertex_Color_Array.Length > 0)
                    {
                        vertices[vOffset + 8] = (uhdBIN.Vertex_Color_Array[i].r / 255f);
                        vertices[vOffset + 9] = (uhdBIN.Vertex_Color_Array[i].g / 255f);
                        vertices[vOffset + 10] = (uhdBIN.Vertex_Color_Array[i].b / 255f);
                        vertices[vOffset + 11] = (uhdBIN.Vertex_Color_Array[i].a / 255f);
                    }
                    else 
                    {
                        vertices[vOffset + 8] = 1f;
                        vertices[vOffset + 9] = 1f;
                        vertices[vOffset + 10] = 1f;
                        vertices[vOffset + 11] = 1f;
                    }

                    vOffset += 12;

                    //seta para caso não tenha
                    if (!boundary.ContainsKey(Boundary.max))
                    {
                        boundary.Add(Boundary.max, point.Xyz);
                    }

                    if (!boundary.ContainsKey(Boundary.min))
                    {
                        boundary.Add(Boundary.min, point.Xyz);
                    }

                    // MAX
                    if (boundary[Boundary.max].X < point.X)
                    {
                        var p = boundary[Boundary.max];
                        p.X = point.X;
                        boundary[Boundary.max] = p;
                    }

                    if (boundary[Boundary.max].Y < point.Y)
                    {
                        var p = boundary[Boundary.max];
                        p.Y = point.Y;
                        boundary[Boundary.max] = p;
                    }

                    if (boundary[Boundary.max].Z < point.Z)
                    {
                        var p = boundary[Boundary.max];
                        p.Z = point.Z;
                        boundary[Boundary.max] = p;
                    }

                    //MIN
                    if (boundary[Boundary.min].X > point.X)
                    {
                        var p = boundary[Boundary.min];
                        p.X = point.X;
                        boundary[Boundary.min] = p;
                    }

                    if (boundary[Boundary.min].Y > point.Y)
                    {
                        var p = boundary[Boundary.min];
                        p.Y = point.Y;
                        boundary[Boundary.min] = p;
                    }

                    if (boundary[Boundary.min].Z > point.Z)
                    {
                        var p = boundary[Boundary.min];
                        p.Z = point.Z;
                        boundary[Boundary.min] = p;
                    }

                }

                baseIndex = maxIndex + 1;

                Vector3 bmin = Vector3.Zero;
                Vector3 bmax = Vector3.Zero;

                if (boundary.ContainsKey(Boundary.max))
                {
                    bmax = boundary[Boundary.max];
                }

                if (boundary.ContainsKey(Boundary.min))
                {
                    bmin = boundary[Boundary.min];
                }


                MeshPart mesh = new MeshPart();
                mesh.Vertex = vertices;
                mesh.Indexes = indices;
                mesh.MinBoundary = bmin;
                mesh.MaxBoundary = bmax;
                mesh.CenterBoundary = new Vector3((bmax.X + bmin.X) / 2, (bmax.Y + bmin.Y) / 2, (bmax.Z + bmin.Z) / 2);
                mesh.RefModelID = FileID;
                mesh.MeshID = im.ToString();
                mesh.MaterialRef = im.ToString();
                treatedModel.Meshes.Add(mesh);
            }

        }

        public static void PopulateMaterialGroup(ref MaterialGroup materialGroup, ref UhdBIN uhdBIN) 
        {
            //material
            for (int i = 0; i < uhdBIN.Materials.Length; i++)
            {
                Material material = new Material(i.ToString());
                material.DiffuseMatTex = uhdBIN.Materials[i].material.diffuse_map.ToString();
                material.AsAlphaTex = false;
                material.AlphaMatTex = "";

                if ((uhdBIN.Materials[i].material.material_flag & 0x04) == 0x04)
                {
                    material.AsAlphaTex = true;
                    material.AlphaMatTex = uhdBIN.Materials[i].material.opacity_map.ToString();
                }

                material.MatColor = Vector4.One;
                materialGroup.MaterialsDic.Add(material.MaterialName, material);
            }

        }

        public static void BoundaryCalculationTreatedModel(ref TreatedModel treatedModel)
        {
            Dictionary<Boundary, Vector3> oboundary = new Dictionary<Boundary, Vector3>();
            if (treatedModel.Meshes.Count != 0)
            {
                oboundary.Add(Boundary.max, treatedModel.Meshes[0].MaxBoundary);
                oboundary.Add(Boundary.min, treatedModel.Meshes[0].MinBoundary);
            }
            else
            {
                oboundary.Add(Boundary.max, Vector3.Zero);
                oboundary.Add(Boundary.min, Vector3.Zero);
            }

            for (int i = 1; i < treatedModel.Meshes.Count; i++)
            {
                // MAX
                if (oboundary[Boundary.max].X < treatedModel.Meshes[i].MaxBoundary.X)
                {
                    var p = oboundary[Boundary.max];
                    p.X = treatedModel.Meshes[i].MaxBoundary.X;
                    oboundary[Boundary.max] = p;
                }

                if (oboundary[Boundary.max].Y < treatedModel.Meshes[i].MaxBoundary.Y)
                {
                    var p = oboundary[Boundary.max];
                    p.Y = treatedModel.Meshes[i].MaxBoundary.Y;
                    oboundary[Boundary.max] = p;
                }

                if (oboundary[Boundary.max].Z < treatedModel.Meshes[i].MaxBoundary.Z)
                {
                    var p = oboundary[Boundary.max];
                    p.Z = treatedModel.Meshes[i].MaxBoundary.Z;
                    oboundary[Boundary.max] = p;
                }

                //MIN
                if (oboundary[Boundary.min].X < treatedModel.Meshes[i].MinBoundary.X)
                {
                    var p = oboundary[Boundary.min];
                    p.X = treatedModel.Meshes[i].MinBoundary.X;
                    oboundary[Boundary.min] = p;
                }

                if (oboundary[Boundary.min].Y < treatedModel.Meshes[i].MinBoundary.Y)
                {
                    var p = oboundary[Boundary.min];
                    p.Y = treatedModel.Meshes[i].MinBoundary.Y;
                    oboundary[Boundary.min] = p;
                }

                if (oboundary[Boundary.min].Z < treatedModel.Meshes[i].MinBoundary.Z)
                {
                    var p = oboundary[Boundary.min];
                    p.Z = treatedModel.Meshes[i].MinBoundary.Z;
                    oboundary[Boundary.min] = p;
                }

            }

            Vector3 omin = oboundary[Boundary.min];
            Vector3 omax = oboundary[Boundary.max];

            treatedModel.MinBoundary = omin;
            treatedModel.MaxBoundary = omax;
            treatedModel.CenterBoundary = new Vector3((omax.X + omin.X) / 2, (omax.Y + omin.Y) / 2, (omax.Z + omin.Z) / 2);
        }

    }
}
