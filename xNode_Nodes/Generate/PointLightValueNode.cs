using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PointLight Value")]
    public partial class PointLightValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.PointLight _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.PointLight);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}