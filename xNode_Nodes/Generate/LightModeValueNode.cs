using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightMode Value")]
    public partial class LightModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.LightMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.LightMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}