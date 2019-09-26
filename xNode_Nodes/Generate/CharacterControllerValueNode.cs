using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CharacterController Value")]
    public partial class CharacterControllerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CharacterController _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CharacterController);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}