using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/ToggleGroup Value")]
    public partial class ToggleGroupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.ToggleGroup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.ToggleGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}