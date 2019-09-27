using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightType Value")]
    public partial class LightTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.LightType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.LightType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}