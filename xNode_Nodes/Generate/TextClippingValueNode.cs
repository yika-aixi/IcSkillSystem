using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/TextClipping Value")]
    public partial class TextClippingValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TextClipping _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TextClipping);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}