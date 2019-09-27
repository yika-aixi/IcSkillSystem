using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GraphicsFormat Value")]
    public partial class GraphicsFormatValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.Rendering.GraphicsFormat _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.Rendering.GraphicsFormat);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}