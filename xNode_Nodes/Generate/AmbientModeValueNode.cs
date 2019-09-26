using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/AmbientMode Value")]
    public partial class AmbientModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.AmbientMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.AmbientMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}