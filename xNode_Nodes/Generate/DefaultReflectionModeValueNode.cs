using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DefaultReflectionMode Value")]
    public partial class DefaultReflectionModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.DefaultReflectionMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.DefaultReflectionMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}