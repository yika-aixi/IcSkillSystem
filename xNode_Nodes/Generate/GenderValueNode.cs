using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UnityAnalyticsModule/Gender Value")]
    public partial class GenderValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Analytics.Gender _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Analytics.Gender);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}