using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/Collision2D Value")]
    public partial class Collision2DValueNode:ValueNode<UnityEngine.Collision2D>
    {
        [SerializeField]
        private UnityEngine.Collision2D _value;
   
        protected override UnityEngine.Collision2D GetTValue()
        {
            return _value;
        }
    }
}