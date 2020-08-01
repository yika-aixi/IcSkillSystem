using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/DistanceJoint2D Value")]
    public partial class DistanceJoint2DValueNode:ValueNode<UnityEngine.DistanceJoint2D>
    {
        [SerializeField]
        private UnityEngine.DistanceJoint2D _value;
   
        protected override UnityEngine.DistanceJoint2D GetTValue()
        {
            return _value;
        }
    }
}