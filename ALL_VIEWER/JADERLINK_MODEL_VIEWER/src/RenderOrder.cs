using System.Collections.Generic;
using ViewerBase;

namespace JADERLINK_MODEL_VIEWER.src
{
    public class RenderOrder
    {
        public List<string> MeshOrder { get; private set; }

        public RenderOrder()
        {
            MeshOrder = new List<string>();
        }

        public void ToOrder(ref ModelGroup modelGroup, List<string> NodeOrder)  
        {
            MeshOrder.Clear();
            foreach (var item in modelGroup.MeshParts)
            {
                string modelID = item.Value.RefModelID;
                if (NodeOrder.Contains(modelID))
                {
                    MeshOrder.Add(item.Key);
                }               
            }
        }
    }
}
