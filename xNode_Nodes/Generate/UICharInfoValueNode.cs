using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/TextRenderingModule/UICharInfo Value")]
    public partial class UICharInfoValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UICharInfo _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UICharInfo);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}