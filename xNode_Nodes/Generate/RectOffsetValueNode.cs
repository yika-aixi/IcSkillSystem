using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RectOffset Value")]
    public partial class RectOffsetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RectOffset _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RectOffset);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}