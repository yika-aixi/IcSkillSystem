using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MotionVectorGenerationMode Value")]
    public partial class MotionVectorGenerationModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MotionVectorGenerationMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MotionVectorGenerationMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}