using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DirectionalLight Value")]
    public partial class DirectionalLightValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.DirectionalLight _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.DirectionalLight);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}