using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/HingeJoint2D Value")]
    public partial class HingeJoint2DValueNode:ValueNode<UnityEngine.HingeJoint2D>
    {
        [SerializeField]
        private UnityEngine.HingeJoint2D _value;
   
        protected override UnityEngine.HingeJoint2D GetTValue()
        {
            return _value;
        }
    }
}