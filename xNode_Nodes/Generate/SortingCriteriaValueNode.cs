using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SortingCriteria Value")]
    public partial class SortingCriteriaValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.SortingCriteria _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.SortingCriteria);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}