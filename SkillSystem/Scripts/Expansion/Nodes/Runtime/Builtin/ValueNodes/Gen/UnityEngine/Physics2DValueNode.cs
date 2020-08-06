using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/Physics2D Value")]
    public partial class Physics2DValueNode:ValueNode<UnityEngine.Physics2D>
    {
        [SerializeField]
        private UnityEngine.Physics2D _value;
   
        protected override UnityEngine.Physics2D GetTValue()
        {
            return _value;
        }
    }
}