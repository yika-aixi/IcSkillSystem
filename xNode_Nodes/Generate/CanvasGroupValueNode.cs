using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIModule/CanvasGroup Value")]
    public partial class CanvasGroupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CanvasGroup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CanvasGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}