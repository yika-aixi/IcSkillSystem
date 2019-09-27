using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FilteringSettings Value")]
    public partial class FilteringSettingsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.FilteringSettings _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.FilteringSettings);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}