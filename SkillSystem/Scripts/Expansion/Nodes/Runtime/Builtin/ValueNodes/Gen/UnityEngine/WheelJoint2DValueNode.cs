using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/WheelJoint2D Value")]
    public partial class WheelJoint2DValueNode:ValueNode<UnityEngine.WheelJoint2D>
    {
        [SerializeField]
        private UnityEngine.WheelJoint2D _value;
   
        protected override UnityEngine.WheelJoint2D GetTValue()
        {
            return _value;
        }
    }
}