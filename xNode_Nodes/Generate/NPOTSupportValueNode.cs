using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/NPOTSupport Value")]
    public partial class NPOTSupportValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.NPOTSupport _value;

        public override Type ValueType { get; } = typeof(UnityEngine.NPOTSupport);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}