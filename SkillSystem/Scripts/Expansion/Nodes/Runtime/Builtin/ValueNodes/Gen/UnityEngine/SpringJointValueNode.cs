using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/SpringJoint Value")]
    public partial class SpringJointValueNode:ValueNode<UnityEngine.SpringJoint>
    {
        [SerializeField]
        private UnityEngine.SpringJoint _value;
   
        protected override UnityEngine.SpringJoint GetTValue()
        {
            return _value;
        }
    }
}