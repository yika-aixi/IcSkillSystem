using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GraphicsDeviceType Value")]
    public partial class GraphicsDeviceTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.GraphicsDeviceType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.GraphicsDeviceType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}