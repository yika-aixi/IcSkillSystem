using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FalloffType Value")]
    public partial class FalloffTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.FalloffType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.FalloffType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}