using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/Rigidbody2D Value")]
    public partial class Rigidbody2DValueNode:ValueNode<UnityEngine.Rigidbody2D>
    {
        [SerializeField]
        private UnityEngine.Rigidbody2D _value;
   
        protected override UnityEngine.Rigidbody2D GetTValue()
        {
            return _value;
        }
    }
}