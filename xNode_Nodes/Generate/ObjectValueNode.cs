using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Object Value")]
    public partial class ObjectValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Object _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Object);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}