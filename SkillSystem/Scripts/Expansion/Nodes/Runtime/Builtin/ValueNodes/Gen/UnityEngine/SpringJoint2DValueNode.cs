using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/SpringJoint2D Value")]
    public partial class SpringJoint2DValueNode:ValueNode<UnityEngine.SpringJoint2D>
    {
        [SerializeField]
        private UnityEngine.SpringJoint2D _value;
   
        protected override UnityEngine.SpringJoint2D GetTValue()
        {
            return _value;
        }
    }
}