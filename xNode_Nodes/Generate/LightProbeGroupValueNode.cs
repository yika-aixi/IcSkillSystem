using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightProbeGroup Value")]
    public partial class LightProbeGroupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightProbeGroup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightProbeGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}