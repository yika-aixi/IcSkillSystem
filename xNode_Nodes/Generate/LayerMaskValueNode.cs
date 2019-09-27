using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LayerMask Value")]
    public partial class LayerMaskValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LayerMask _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LayerMask);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}