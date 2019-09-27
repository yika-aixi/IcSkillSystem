using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/OpaqueSortMode Value")]
    public partial class OpaqueSortModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.OpaqueSortMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.OpaqueSortMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}