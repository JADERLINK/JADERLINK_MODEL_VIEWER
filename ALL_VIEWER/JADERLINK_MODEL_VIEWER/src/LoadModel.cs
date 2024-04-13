using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

                MeshPart mesh = new MeshPart();
                mesh.Vertex = verticesList.ToArray();
                mesh.Indexes = indicesList.ToArray();
                mesh.MinBoundary = bmin;
                mesh.MaxBoundary = bmax;
                mesh.CenterBoundary = new Vector3((bmax.X + bmin.X) / 2, (bmax.Y + bmin.Y) / 2, (bmax.Z + bmin.Z) / 2);
                mesh.RefModelID = FileID;
                mesh.MeshID = faceByMaterial.Key;
                mesh.MaterialRef = faceByMaterial.Key;
                treatedModel.Meshes.Add(mesh);

            }
        }



        public static void BoundaryCalculationTreatedModel(ref TreatedModel treatedModel)
        {
            // calculo Boundary do objeto.
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
