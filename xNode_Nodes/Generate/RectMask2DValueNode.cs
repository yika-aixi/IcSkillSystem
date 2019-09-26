using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/RectMask2D Value")]
    public partial class RectMask2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.RectMask2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.RectMask2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}