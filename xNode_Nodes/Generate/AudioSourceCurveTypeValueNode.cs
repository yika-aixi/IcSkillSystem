using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/AudioModule/AudioSourceCurveType Value")]
    public partial class AudioSourceCurveTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AudioSourceCurveType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AudioSourceCurveType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}