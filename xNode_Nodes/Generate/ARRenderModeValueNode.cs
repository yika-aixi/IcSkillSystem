using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ARModule/ARRenderMode Value")]
    public partial class ARRenderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.XR.ARRenderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.XR.ARRenderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}