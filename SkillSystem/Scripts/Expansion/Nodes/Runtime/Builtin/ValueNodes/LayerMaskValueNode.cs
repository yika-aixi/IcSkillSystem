using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Layer Mask")]
    public class LayerMaskValueNode:ValueNode
    {
        public override Type ValueType { get; } = typeof(LayerMask);

        [SerializeField]
        private LayerMask _mask;
        
        protected override object GetOutValue()
        {
            return _mask;
        }
    }
}