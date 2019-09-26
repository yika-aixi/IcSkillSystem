using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/CanvasScaler Value")]
    public partial class CanvasScalerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.CanvasScaler _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.CanvasScaler);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}