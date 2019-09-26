using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ForcedCrashCategory Value")]
    public partial class ForcedCrashCategoryValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Diagnostics.ForcedCrashCategory _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Diagnostics.ForcedCrashCategory);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}