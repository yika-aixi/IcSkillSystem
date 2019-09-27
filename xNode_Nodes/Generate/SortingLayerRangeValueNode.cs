using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SortingLayerRange Value")]
    public partial class SortingLayerRangeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.SortingLayerRange _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.SortingLayerRange);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}