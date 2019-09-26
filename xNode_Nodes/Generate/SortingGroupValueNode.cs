using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SortingGroup Value")]
    public partial class SortingGroupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.SortingGroup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.SortingGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}