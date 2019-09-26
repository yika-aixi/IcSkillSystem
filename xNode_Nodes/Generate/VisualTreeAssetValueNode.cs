using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIElementsModule/VisualTreeAsset Value")]
    public partial class VisualTreeAssetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UIElements.VisualTreeAsset _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UIElements.VisualTreeAsset);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}