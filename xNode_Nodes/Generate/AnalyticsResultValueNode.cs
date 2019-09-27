using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UnityAnalyticsModule/AnalyticsResult Value")]
    public partial class AnalyticsResultValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Analytics.AnalyticsResult _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Analytics.AnalyticsResult);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}