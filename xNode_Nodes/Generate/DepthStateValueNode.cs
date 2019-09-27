using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DepthState Value")]
    public partial class DepthStateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.DepthState _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.DepthState);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}