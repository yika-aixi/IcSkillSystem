using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextCoreModule/FontEngineError Value")]
    public partial class FontEngineErrorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextCore.LowLevel.FontEngineError _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextCore.LowLevel.FontEngineError);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}