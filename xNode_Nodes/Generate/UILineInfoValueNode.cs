using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/UILineInfo Value")]
    public partial class UILineInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UILineInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UILineInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}