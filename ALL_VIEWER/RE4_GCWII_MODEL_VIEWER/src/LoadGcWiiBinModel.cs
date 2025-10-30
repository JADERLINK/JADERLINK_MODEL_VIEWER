using JADERLINK_MODEL_VIEWER.src.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using ViewerBase;
using SHARED_GCWII_BIN.EXTRACT;
using SHARED_GCWII_BIN.ALL;
using OpenTK;
using SHARED_TOOLS.ALL;

namespace RE4_GCWII_MODEL_VIEWER.src
{
    public class LoadGcWiiBinModel
    {
        public Action<TreatedModel> ExternalAddTreatedModel;

        private ModelGroup modelGroup;
        private ModelNodeGroup mng;

        public LoadGcWiiBinModel(ModelGroup modelGroup, ModelNodeGroup mng)
        {
            this.modelGroup = modelGroup;
            this.mng = mng;
        }

        public void LoadGcWiiBIN(string binPath)
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
                GCWIIBIN bin = null;
                Stream binFile = null;
                try
                {
                    binFile = fileInfo.OpenRead();
                    bin = GcWiiBinDecoder.Decoder(binFile, 0, out _);
                }
                catch (Exception)
                {
                }
                finally
                {
                    binFile?.Close();
                }


                if (bin != null)
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
                    PopulateTreatedModel(ref treatedModel, ref bin, FileID);

                    //materialGroup
                    PopulateMaterialGroup(ref materialGroup, ref bin);

                    // calculo Boundary do objeto.
                    BoundaryCalculation.TreatedModel(ref treatedModel);

                    //armazena o modelo em local externo
                    ExternalAddTreatedModel?.Invoke(treatedModel);

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

        private static float get_scale_from_vertex_scale(byte vertex_scale)
        {
            return (float)Math.Pow(2, vertex_scale);
        }

        public static void PopulateTreatedModel(ref TreatedModel treatedModel, ref GCWIIBIN bin, string FileID)
        {
            //model
            for (int im = 0; im < bin.Materials.Length; im++)
            {
                Dictionary<Boundary, Vector3> boundary = new Dictionary<Boundary, Vector3>();

                List<uint> indicesList = new List<uint>();

                // old Ids list, list position is new id
                List<(int icolor, int ivertex, int inormal, int itex)> order = new List<(int icolor, int ivertex, int inormal, int itex)>();

                for (int i = 0; i < bin.Materials[im].face_index_array.Length; i++)
                {
                    int color_id1 = -1;
                    int color_id2 = -1;
                    int color_id3 = -1;

                    if (bin.Header.ReturnsHasEnableVertexColorsTag())
                    {
                        color_id1 = bin.Materials[im].face_index_array[i].i1.indexColor;
                        color_id2 = bin.Materials[im].face_index_array[i].i2.indexColor;
                        color_id3 = bin.Materials[im].face_index_array[i].i3.indexColor;
                    }

                    int avid = bin.Materials[im].face_index_array[i].i1.indexVertex;
                    int bvid = bin.Materials[im].face_index_array[i].i2.indexVertex;
                    int cvid = bin.Materials[im].face_index_array[i].i3.indexVertex;

                    int an = bin.Materials[im].face_index_array[i].i1.indexNormal;
                    int bn = bin.Materials[im].face_index_array[i].i2.indexNormal;
                    int cn = bin.Materials[im].face_index_array[i].i3.indexNormal;

                    int at = bin.Materials[im].face_index_array[i].i1.indexUV;
                    int bt = bin.Materials[im].face_index_array[i].i2.indexUV;
                    int ct = bin.Materials[im].face_index_array[i].i3.indexUV;

                    var key1 = (color_id1, avid, an, at);
                    var key2 = (color_id2, bvid, bn, bt);
                    var key3 = (color_id3, cvid, cn, ct);

                    if (!order.Contains(key1))
                    {
                        order.Add(key1);
                    }
                    if (!order.Contains(key2))
                    {
                        order.Add(key2);
                    }
                    if (!order.Contains(key3))
                    {
                        order.Add(key3);
                    }
                    uint index1 = (uint)order.IndexOf(key1);
                    uint index2 = (uint)order.IndexOf(key2);
                    uint index3 = (uint)order.IndexOf(key3);

                    indicesList.Add(index1);
                    indicesList.Add(index2);
                    indicesList.Add(index3);
                }

                int IndexesLength = indicesList.Count;
                int rest = (IndexesLength % 4) - 4;
                for (int i = 0; i < rest; i++)
                {
                    indicesList.Add(0);
                }

                int count = order.Count;
                float[] vertices = new float[count * 12];

                float extraScale = CONSTs.GLOBAL_POSITION_SCALE * get_scale_from_vertex_scale(bin.Header.vertex_scale);

                int vOffset = 0;
                for (int i = 0; i < count; i++)
                {
                    float vx = bin.Vertex_Position_Array[order[i].ivertex].vx / extraScale;
                    float vy = bin.Vertex_Position_Array[order[i].ivertex].vy / extraScale;
                    float vz = bin.Vertex_Position_Array[order[i].ivertex].vz / extraScale;

                    var point = new Vector4(vx, vy, vz, 1);

                    vertices[vOffset + 0] = point.X;
                    vertices[vOffset + 1] = point.Y;
                    vertices[vOffset + 2] = point.Z;

                    float nx = bin.Vertex_Normal_Array[order[i].inormal].nx;
                    float ny = bin.Vertex_Normal_Array[order[i].inormal].ny;
                    float nz = bin.Vertex_Normal_Array[order[i].inormal].nz;

                    float NORMAL_FIX = (float)Math.Sqrt((nx * nx) + (ny * ny) + (nz * nz));
                    NORMAL_FIX = (NORMAL_FIX == 0) ? 1 : NORMAL_FIX;
                    nx /= NORMAL_FIX;
                    ny /= NORMAL_FIX;
                    nz /= NORMAL_FIX;

                    vertices[vOffset + 3] = nx;
                    vertices[vOffset + 4] = ny;
                    vertices[vOffset + 5] = nz;

                    float tu;
                    float tv;

                    if (bin.Header.ReturnHasEnableModernStyle())
                    {
                        tu = bin.Vertex_UV_Array[order[i].itex].tu / (float)byte.MaxValue;
                        tv = bin.Vertex_UV_Array[order[i].itex].tv / (float)byte.MaxValue;
                    }
                    else
                    {
                        tu = bin.Vertex_UV_Array[order[i].itex].tu / (float)short.MaxValue;
                        tv = bin.Vertex_UV_Array[order[i].itex].tv / (float)short.MaxValue;
                    }

                    vertices[vOffset + 6] = tu;
                    vertices[vOffset + 7] = tv;

                    if (bin.Header.ReturnsHasEnableVertexColorsTag() && bin.Vertex_Color_Array.Length > order[i].icolor && order[i].icolor > -1)
                    {
                        vertices[vOffset + 8] = (bin.Vertex_Color_Array[order[i].icolor].r / 255f);
                        vertices[vOffset + 9] = (bin.Vertex_Color_Array[order[i].icolor].g / 255f);
                        vertices[vOffset + 10] = (bin.Vertex_Color_Array[order[i].icolor].b / 255f);
                        vertices[vOffset + 11] = (bin.Vertex_Color_Array[order[i].icolor].a / 255f);
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
                mesh.Indexes = indicesList.ToArray();
                mesh.IndexesLength = IndexesLength;
                mesh.MinBoundary = bmin;
                mesh.MaxBoundary = bmax;
                mesh.CenterBoundary = new Vector3((bmax.X + bmin.X) / 2, (bmax.Y + bmin.Y) / 2, (bmax.Z + bmin.Z) / 2);
                mesh.RefModelID = FileID;
                mesh.MeshID = im.ToString();
                mesh.MaterialRef = im.ToString();
                treatedModel.Meshes.Add(mesh);
            }

        }

        public static void PopulateMaterialGroup(ref MaterialGroup materialGroup, ref GCWIIBIN uhdBIN)
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

    }
}
