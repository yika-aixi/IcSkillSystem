using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/Cursor Value")]
    public partial class CursorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.Cursor _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.Cursor);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}