using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ConstantForce2D Value")]
    public partial class ConstantForce2DValueNode:ValueNode<UnityEngine.ConstantForce2D>
    {
        [SerializeField]
        private UnityEngine.ConstantForce2D _value;
   
        protected override UnityEngine.ConstantForce2D GetTValue()
        {
            return _value;
        }
    }
}