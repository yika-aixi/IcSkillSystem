using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SpherecastCommand Value")]
    public partial class SpherecastCommandValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpherecastCommand _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpherecastCommand);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}