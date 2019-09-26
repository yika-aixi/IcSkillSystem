using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Selectable Value")]
    public partial class SelectableValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Selectable _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Selectable);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}