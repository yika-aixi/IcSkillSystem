using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionProbe Value")]
    public partial class ReflectionProbeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ReflectionProbe _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ReflectionProbe);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}