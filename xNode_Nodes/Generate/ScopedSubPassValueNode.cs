using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ScopedSubPass Value")]
    public partial class ScopedSubPassValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ScopedSubPass _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ScopedSubPass);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}