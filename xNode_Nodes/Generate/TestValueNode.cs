using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/Test Value")]
    public partial class TestValueNode:ValueNode
    {
        [SerializeField]
        private Buff.Components.Test.Test _value;

        public override Type ValueType { get; } = typeof(Buff.Components.Test.Test);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}