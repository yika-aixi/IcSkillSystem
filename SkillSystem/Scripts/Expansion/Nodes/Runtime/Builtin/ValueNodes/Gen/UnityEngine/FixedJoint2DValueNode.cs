using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/FixedJoint2D Value")]
    public partial class FixedJoint2DValueNode:ValueNode<UnityEngine.FixedJoint2D>
    {
        [SerializeField]
        private UnityEngine.FixedJoint2D _value;
   
        protected override UnityEngine.FixedJoint2D GetTValue()
        {
            return _value;
        }
    }
}