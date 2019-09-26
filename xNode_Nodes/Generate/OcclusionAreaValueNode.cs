using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/OcclusionArea Value")]
    public partial class OcclusionAreaValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.OcclusionArea _value;

        public override Type ValueType { get; } = typeof(UnityEngine.OcclusionArea);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}