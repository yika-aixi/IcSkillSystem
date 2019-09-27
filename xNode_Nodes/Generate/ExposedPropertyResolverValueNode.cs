using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ExposedPropertyResolver Value")]
    public partial class ExposedPropertyResolverValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ExposedPropertyResolver _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ExposedPropertyResolver);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}