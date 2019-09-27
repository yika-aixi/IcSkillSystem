using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LinearColor Value")]
    public partial class LinearColorValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.LinearColor _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.LinearColor);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}