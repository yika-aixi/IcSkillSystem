using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/AspectRatioFitter Value")]
    public partial class AspectRatioFitterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.AspectRatioFitter _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.AspectRatioFitter);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}