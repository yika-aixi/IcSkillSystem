using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/RaycastCommand Value")]
    public partial class RaycastCommandValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RaycastCommand _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RaycastCommand);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}