using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpotLight Value")]
    public partial class SpotLightValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.SpotLight _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.SpotLight);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}