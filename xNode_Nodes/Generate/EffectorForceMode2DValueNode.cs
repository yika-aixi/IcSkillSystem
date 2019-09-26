using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/EffectorForceMode2D Value")]
    public partial class EffectorForceMode2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.EffectorForceMode2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.EffectorForceMode2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}