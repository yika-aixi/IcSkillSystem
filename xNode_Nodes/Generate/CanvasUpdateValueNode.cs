using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/CanvasUpdate Value")]
    public partial class CanvasUpdateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.CanvasUpdate _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.CanvasUpdate);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}