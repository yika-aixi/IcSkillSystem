using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CoveredMethodStats Value")]
    public partial class CoveredMethodStatsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TestTools.CoveredMethodStats _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TestTools.CoveredMethodStats);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}