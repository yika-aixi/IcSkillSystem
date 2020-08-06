using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/SliderJoint2D Value")]
    public partial class SliderJoint2DValueNode:ValueNode<UnityEngine.SliderJoint2D>
    {
        [SerializeField]
        private UnityEngine.SliderJoint2D _value;
   
        protected override UnityEngine.SliderJoint2D GetTValue()
        {
            return _value;
        }
    }
}