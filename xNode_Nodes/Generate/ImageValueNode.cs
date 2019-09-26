using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/Image Value")]
    public partial class ImageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.Image _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.Image);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}