using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/ParticleSystemModule/ParticleSystemCurveMode Value")]
    public partial class ParticleSystemCurveModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ParticleSystemCurveMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ParticleSystemCurveMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}