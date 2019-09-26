using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Mask Value")]
    public partial class MaskValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Mask _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Mask);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}