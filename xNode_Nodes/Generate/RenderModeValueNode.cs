using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UIModule/RenderMode Value")]
    public partial class RenderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}