using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/InputLegacyModule/TouchType Value")]
    public partial class TouchTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TouchType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TouchType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}