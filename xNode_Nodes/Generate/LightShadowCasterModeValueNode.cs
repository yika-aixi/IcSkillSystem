using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightShadowCasterMode Value")]
    public partial class LightShadowCasterModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightShadowCasterMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightShadowCasterMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}