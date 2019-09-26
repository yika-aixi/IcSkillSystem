using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Dropdown Value")]
    public partial class DropdownValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Dropdown _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Dropdown);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}