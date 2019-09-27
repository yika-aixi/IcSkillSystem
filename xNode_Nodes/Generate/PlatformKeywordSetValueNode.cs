using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlatformKeywordSet Value")]
    public partial class PlatformKeywordSetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.PlatformKeywordSet _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.PlatformKeywordSet);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}