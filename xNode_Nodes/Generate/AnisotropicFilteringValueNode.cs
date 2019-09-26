using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/AnisotropicFiltering Value")]
    public partial class AnisotropicFilteringValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AnisotropicFiltering _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AnisotropicFiltering);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}