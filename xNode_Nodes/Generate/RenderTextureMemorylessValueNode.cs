using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderTextureMemoryless Value")]
    public partial class RenderTextureMemorylessValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderTextureMemoryless _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderTextureMemoryless);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}