using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/FrictionJoint2D Value")]
    public partial class FrictionJoint2DValueNode:ValueNode<UnityEngine.FrictionJoint2D>
    {
        [SerializeField]
        private UnityEngine.FrictionJoint2D _value;
   
        protected override UnityEngine.FrictionJoint2D GetTValue()
        {
            return _value;
        }
    }
}