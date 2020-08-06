using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CharacterController Value")]
    public partial class CharacterControllerValueNode:ValueNode<UnityEngine.CharacterController>
    {
        [SerializeField]
        private UnityEngine.CharacterController _value;
   
        protected override UnityEngine.CharacterController GetTValue()
        {
            return _value;
        }
    }
}