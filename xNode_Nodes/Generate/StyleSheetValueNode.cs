using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/StyleSheet Value")]
    public partial class StyleSheetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.StyleSheet _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.StyleSheet);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}