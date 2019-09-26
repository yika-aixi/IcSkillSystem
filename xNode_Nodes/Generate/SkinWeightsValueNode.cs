using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SkinWeights Value")]
    public partial class SkinWeightsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SkinWeights _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SkinWeights);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}