using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/ForceMode2D Value")]
    public partial class ForceMode2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ForceMode2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ForceMode2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}