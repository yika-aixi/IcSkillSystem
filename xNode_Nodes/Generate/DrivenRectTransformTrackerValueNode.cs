using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DrivenRectTransformTracker Value")]
    public partial class DrivenRectTransformTrackerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.DrivenRectTransformTracker _value;

        public override Type ValueType { get; } = typeof(UnityEngine.DrivenRectTransformTracker);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}