using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/WrapMode Value")]
    public partial class WrapModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.WrapMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.WrapMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}