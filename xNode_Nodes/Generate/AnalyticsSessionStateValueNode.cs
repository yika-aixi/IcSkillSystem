using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UnityAnalyticsModule/AnalyticsSessionState Value")]
    public partial class AnalyticsSessionStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Analytics.AnalyticsSessionState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Analytics.AnalyticsSessionState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}