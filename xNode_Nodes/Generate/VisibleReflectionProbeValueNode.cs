using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/VisibleReflectionProbe Value")]
    public partial class VisibleReflectionProbeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.VisibleReflectionProbe _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.VisibleReflectionProbe);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}