using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/HingeJoint Value")]
    public partial class HingeJointValueNode:ValueNode<UnityEngine.HingeJoint>
    {
        [SerializeField]
        private UnityEngine.HingeJoint _value;
   
        protected override UnityEngine.HingeJoint GetTValue()
        {
            return _value;
        }
    }
}