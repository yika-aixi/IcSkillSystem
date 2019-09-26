using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RectTransform Value")]
    public partial class RectTransformValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RectTransform _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RectTransform);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}