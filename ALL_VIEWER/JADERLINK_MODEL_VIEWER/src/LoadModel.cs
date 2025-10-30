using System.Collections.Generic;
using System.Linq;
using OpenTK;
using ViewerBase;
using JADERLINK_MODEL_VIEWER.src.Structures;

namespace JADERLINK_MODEL_VIEWER.src
{
    public static class LoadModel
    {

        public static void PopulateTreatedModel(ref TreatedModel treatedModel, ref StartStructure startStructure, string FileID) 
        {
            //mesh
            string[] Materials = startStructure.FacesByMaterial.Keys.OrderBy(x => x).ToArray();

            for (int im = 0; im < Materials.Length; im++)
            {
                KeyValuePair<string, StartFacesGroup> faceByMaterial = new KeyValuePair<string, StartFacesGroup>(Materials[im], startStructure.FacesByMaterial[Materials[im]]);

                Dictionary<Boundary, Vector3> boundary = new Dictionary<Boundary, Vector3>();

                List<float> verticesList = new List<float>();
                List<uint> indicesList = new List<uint>();

                uint IndexCounter = 0;

                for (int i = 0; i < faceByMaterial.Value.Faces.Count; i++)
                {
                    for (int iv = 0; iv < faceByMaterial.Value.Faces[i].Count; iv++)
                    {
                        indicesList.Add(IndexCounter);
                        IndexCounter++;

                        var point = new Vector4(faceByMaterial.Value.Faces[i][iv].Position.X, faceByMaterial.Value.Faces[i][iv].Position.Y, faceByMaterial.Value.Faces[i][iv].Position.Z, 1);

                        verticesList.Add(point.X);
                        verticesList.Add(point.Y);
                        verticesList.Add(point.Z);

                        verticesList.Add(faceByMaterial.Value.Faces[i][iv].Normal.X);
                        verticesList.Add(faceByMaterial.Value.Faces[i][iv].Normal.Y);
                        verticesList.Add(faceByMaterial.Value.Faces[i][iv].Normal.Z);

                        verticesList.Add(faceByMaterial.Value.Faces[i][iv].Texture.X);
                        verticesList.Add(faceByMaterial.Value.Faces[i][iv].Texture.Y);

                        verticesList.Add(faceByMaterial.Value.Faces[i][iv].Color.X);
                        verticesList.Add(faceByMaterial.Value.Faces[i][iv].Color.Y);
                        verticesList.Add(faceByMaterial.Value.Faces[i][iv].Color.Z);
                        verticesList.Add(faceByMaterial.Value.Faces[i][iv].Color.W);

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

                int IndexesLength = indicesList.Count;

                int tempIndexDiv = IndexesLength / (16 / sizeof(uint));
                int tempIndexRest = IndexesLength % (16 / sizeof(uint));
                tempIndexDiv += tempIndexRest != 0 ? 1 : 0;
                int tempIndexLength = tempIndexDiv * (16 / sizeof(uint));
                indicesList.AddRange(new uint[tempIndexLength - IndexesLength]);

                MeshPart mesh = new MeshPart();
                mesh.Vertex = verticesList.ToArray();
                mesh.Indexes = indicesList.ToArray();
                mesh.IndexesLength = IndexesLength;
                mesh.MinBoundary = bmin;
                mesh.MaxBoundary = bmax;
                mesh.CenterBoundary = new Vector3((bmax.X + bmin.X) / 2, (bmax.Y + bmin.Y) / 2, (bmax.Z + bmin.Z) / 2);
                mesh.RefModelID = FileID;
                mesh.MeshID = faceByMaterial.Key;
                mesh.MaterialRef = faceByMaterial.Key;
                treatedModel.Meshes.Add(mesh);

            }
        }

    }
}
