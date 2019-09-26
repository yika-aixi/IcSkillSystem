using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIModule/CanvasRenderer Value")]
    public partial class CanvasRendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CanvasRenderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CanvasRenderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}