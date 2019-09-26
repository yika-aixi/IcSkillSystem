using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightProbes Value")]
    public partial class LightProbesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightProbes _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightProbes);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}