using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/FFTWindow Value")]
    public partial class FFTWindowValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FFTWindow _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FFTWindow);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}