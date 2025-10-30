using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTK;

namespace JADERLINK_MODEL_VIEWER.src.Structures
{
    public class StartStructure
    {
        /// <summary>
        /// Dicionario, sendo string o nome do material, e StartFacesGroup, objeto que representa as faces do modelo.
        /// </summary>
        public IDictionary<string, StartFacesGroup> FacesByMaterial { get; private set; }


        public StartStructure()
        {
            FacesByMaterial = new Dictionary<string, StartFacesGroup>();
        }

    }

    /// <summary>
    /// Representa o conjunto de pesos associado a um vértice;
    /// </summary>
    public class StartWeightMap : IEquatable<StartWeightMap>
    {
        public int Links { get; set; }

        public int BoneID1 { get; set; }
        public float Weight1 { get; set; }

        public int BoneID2 { get; set; }
        public float Weight2 { get; set; }

        public int BoneID3 { get; set; }
        public float Weight3 { get; set; }

        public StartWeightMap() { }

        public StartWeightMap(int links, int boneID1, float weight1, int boneID2, float weight2, int boneID3, float weight3)
        {
            Links = links;
            BoneID1 = boneID1;
            Weight1 = weight1;
            BoneID2 = boneID2;
            Weight2 = weight2;
            BoneID3 = boneID3;
            Weight3 = weight3;
        }

        public static bool operator ==(StartWeightMap lhs, StartWeightMap rhs) => lhs.Equals(rhs);

        public static bool operator !=(StartWeightMap lhs, StartWeightMap rhs) => !(lhs == rhs);

        public bool Equals(StartWeightMap obj)
        {
            return obj.Links == Links
                && obj.BoneID1 == BoneID1
                && obj.BoneID2 == BoneID2
                && obj.BoneID3 == BoneID3
                && obj.Weight1 == Weight1
                && obj.Weight2 == Weight2
                && obj.Weight3 == Weight3;
        }

        public override bool Equals(object obj)
        {
            return obj is StartWeightMap map
                && map.Links == Links
                && map.BoneID1 == BoneID1
                && map.BoneID2 == BoneID2
                && map.BoneID3 == BoneID3
                && map.Weight1 == Weight1
                && map.Weight2 == Weight2
                && map.Weight3 == Weight3;
        }
        public override int GetHashCode()
        {
            unchecked
            {
                int hash = 17;
                hash = hash * 23 + Links.GetHashCode();
                hash = hash * 23 + BoneID1.GetHashCode();
                hash = hash * 23 + Weight1.GetHashCode();
                hash = hash * 23 + BoneID2.GetHashCode();
                hash = hash * 23 + Weight2.GetHashCode();
                hash = hash * 23 + BoneID3.GetHashCode();
                hash = hash * 23 + Weight3.GetHashCode();
                return hash;
            }
        }


    }


    /// <summary>
    /// Represente um vertice
    /// </summary>
    public class StartVertex
    {
        public Vector3 Position;
        public Vector2 Texture;
        public Vector3 Normal;
        public Vector4 Color;
        public StartWeightMap WeightMap;

        public bool Equals(StartVertex obj)
        {
            return obj.Position == Position
                && obj.Texture == Texture
                && obj.Normal == Normal
                && obj.Color == Color
                && obj.WeightMap == WeightMap;
        }

        public override bool Equals(object obj)
        {
            return obj is StartVertex o
                && o.Position == Position
                && o.Texture == Texture
                && o.Normal == Normal
                && o.Color == Color
                && o.WeightMap == WeightMap;
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Position.GetHashCode() + Texture.GetHashCode() + Normal.GetHashCode() + Color.GetHashCode() + WeightMap.GetHashCode()).GetHashCode();
            }
        }

    }

    public class StartFacesGroup
    {
        /// <summary>
        /// o primeiro List é o conjunto de faces, e o segundo List é o conjunto de vertices
        /// </summary>
        public List<List<StartVertex>> Faces { get; set; }

        public StartFacesGroup()
        {
            Faces = new List<List<StartVertex>>();
        }

        public StartFacesGroup(List<List<StartVertex>> faces)
        {
            Faces = faces;
        }
    }


}
