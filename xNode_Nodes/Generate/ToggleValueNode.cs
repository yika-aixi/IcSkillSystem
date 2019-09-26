using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Toggle Value")]
    public partial class ToggleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Toggle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Toggle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}