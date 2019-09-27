using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RasterState Value")]
    public partial class RasterStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.RasterState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.RasterState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}