using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/ColorBlock Value")]
    public partial class ColorBlockValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.ColorBlock _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.ColorBlock);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}