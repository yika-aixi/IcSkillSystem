using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SortingLayer Value")]
    public partial class SortingLayerValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SortingLayer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SortingLayer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}