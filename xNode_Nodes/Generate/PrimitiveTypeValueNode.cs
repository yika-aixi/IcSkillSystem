using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PrimitiveType Value")]
    public partial class PrimitiveTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.PrimitiveType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.PrimitiveType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}