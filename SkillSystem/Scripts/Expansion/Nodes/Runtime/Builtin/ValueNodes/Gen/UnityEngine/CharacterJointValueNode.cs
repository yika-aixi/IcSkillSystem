using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/CharacterJoint Value")]
    public partial class CharacterJointValueNode:ValueNode<UnityEngine.CharacterJoint>
    {
        [SerializeField]
        private UnityEngine.CharacterJoint _value;
   
        protected override UnityEngine.CharacterJoint GetTValue()
        {
            return _value;
        }
    }
}