using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/BlendState Value")]
    public partial class BlendStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.BlendState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.BlendState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}