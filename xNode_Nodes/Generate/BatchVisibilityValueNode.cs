using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BatchVisibility Value")]
    public partial class BatchVisibilityValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.BatchVisibility _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.BatchVisibility);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}