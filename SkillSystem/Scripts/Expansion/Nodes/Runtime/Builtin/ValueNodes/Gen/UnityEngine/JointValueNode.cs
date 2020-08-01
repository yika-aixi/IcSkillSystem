using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/Joint Value")]
    public partial class JointValueNode:ValueNode<UnityEngine.Joint>
    {
        [SerializeField]
        private UnityEngine.Joint _value;
   
        protected override UnityEngine.Joint GetTValue()
        {
            return _value;
        }
    }
}