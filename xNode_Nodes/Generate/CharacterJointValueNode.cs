using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CharacterJoint Value")]
    public partial class CharacterJointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CharacterJoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CharacterJoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}