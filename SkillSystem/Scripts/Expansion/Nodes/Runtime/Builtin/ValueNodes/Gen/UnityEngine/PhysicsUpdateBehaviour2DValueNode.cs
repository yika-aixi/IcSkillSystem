using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/PhysicsUpdateBehaviour2D Value")]
    public partial class PhysicsUpdateBehaviour2DValueNode:ValueNode<UnityEngine.PhysicsUpdateBehaviour2D>
    {
        [SerializeField]
        private UnityEngine.PhysicsUpdateBehaviour2D _value;
   
        protected override UnityEngine.PhysicsUpdateBehaviour2D GetTValue()
        {
            return _value;
        }
    }
}