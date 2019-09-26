using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Transform Value")]
    public partial class TransformValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Transform _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Transform);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}