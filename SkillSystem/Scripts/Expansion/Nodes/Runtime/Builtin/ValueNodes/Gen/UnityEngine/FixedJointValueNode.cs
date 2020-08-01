using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/FixedJoint Value")]
    public partial class FixedJointValueNode:ValueNode<UnityEngine.FixedJoint>
    {
        [SerializeField]
        private UnityEngine.FixedJoint _value;
   
        protected override UnityEngine.FixedJoint GetTValue()
        {
            return _value;
        }
    }
}