using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/BoxcastCommand Value")]
    public partial class BoxcastCommandValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.BoxcastCommand _value;

        public override Type ValueType { get; } = typeof(UnityEngine.BoxcastCommand);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}