using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionProbeClearFlags Value")]
    public partial class ReflectionProbeClearFlagsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ReflectionProbeClearFlags _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ReflectionProbeClearFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}