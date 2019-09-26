using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RenderingPath Value")]
    public partial class RenderingPathValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.RenderingPath _value;

        public override Type ValueType { get; } = typeof(UnityEngine.RenderingPath);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}