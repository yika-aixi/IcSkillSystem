using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/RelativeJoint2D Value")]
    public partial class RelativeJoint2DValueNode:ValueNode<UnityEngine.RelativeJoint2D>
    {
        [SerializeField]
        private UnityEngine.RelativeJoint2D _value;
   
        protected override UnityEngine.RelativeJoint2D GetTValue()
        {
            return _value;
        }
    }
}