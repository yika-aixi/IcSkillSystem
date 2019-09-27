using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ReflectionProbeSortingCriteria Value")]
    public partial class ReflectionProbeSortingCriteriaValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ReflectionProbeSortingCriteria _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ReflectionProbeSortingCriteria);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}