using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BlendMode Value")]
    public partial class BlendModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.BlendMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.BlendMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}