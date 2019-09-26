using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DistanceMetric Value")]
    public partial class DistanceMetricValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.DistanceMetric _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.DistanceMetric);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}