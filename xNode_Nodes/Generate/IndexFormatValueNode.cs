using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/IndexFormat Value")]
    public partial class IndexFormatValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.IndexFormat _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.IndexFormat);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}