using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FilterMode Value")]
    public partial class FilterModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FilterMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FilterMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}