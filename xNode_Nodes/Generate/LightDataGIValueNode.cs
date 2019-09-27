using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightDataGI Value")]
    public partial class LightDataGIValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.LightDataGI _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.LightDataGI);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}