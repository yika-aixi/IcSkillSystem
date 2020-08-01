using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/AnchoredJoint2D Value")]
    public partial class AnchoredJoint2DValueNode:ValueNode<UnityEngine.AnchoredJoint2D>
    {
        [SerializeField]
        private UnityEngine.AnchoredJoint2D _value;
   
        protected override UnityEngine.AnchoredJoint2D GetTValue()
        {
            return _value;
        }
    }
}