using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightRenderMode Value")]
    public partial class LightRenderModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightRenderMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightRenderMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}