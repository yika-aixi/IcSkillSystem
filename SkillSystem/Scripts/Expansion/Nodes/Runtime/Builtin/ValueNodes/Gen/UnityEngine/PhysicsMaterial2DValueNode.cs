using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PhysicsMaterial2D Value")]
    public partial class PhysicsMaterial2DValueNode:ValueNode<UnityEngine.PhysicsMaterial2D>
    {
        [SerializeField]
        private UnityEngine.PhysicsMaterial2D _value;
   
        protected override UnityEngine.PhysicsMaterial2D GetTValue()
        {
            return _value;
        }
    }
}