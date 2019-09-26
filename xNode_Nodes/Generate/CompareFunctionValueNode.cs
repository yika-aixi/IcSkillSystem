using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CompareFunction Value")]
    public partial class CompareFunctionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.CompareFunction _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.CompareFunction);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}