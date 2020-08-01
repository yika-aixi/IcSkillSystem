using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/TargetJoint2D Value")]
    public partial class TargetJoint2DValueNode:ValueNode<UnityEngine.TargetJoint2D>
    {
        [SerializeField]
        private UnityEngine.TargetJoint2D _value;
   
        protected override UnityEngine.TargetJoint2D GetTValue()
        {
            return _value;
        }
    }
}