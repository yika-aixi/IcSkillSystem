using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIModule/Canvas Value")]
    public partial class CanvasValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Canvas _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Canvas);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}