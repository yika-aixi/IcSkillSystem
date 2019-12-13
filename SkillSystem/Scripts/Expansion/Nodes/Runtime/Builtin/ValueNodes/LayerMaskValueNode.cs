using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Layer Mask")]
    public class LayerMaskValueNode:ValueNode<LayerMask>
    {
        [SerializeField]
        private LayerMask _mask;

        protected override LayerMask GetTValue()
        {
            return _mask;
        }
    }
}