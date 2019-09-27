using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DiscLight Value")]
    public partial class DiscLightValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.DiscLight _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.DiscLight);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}