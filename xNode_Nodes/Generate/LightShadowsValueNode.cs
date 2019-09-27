using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightShadows Value")]
    public partial class LightShadowsValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LightShadows _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LightShadows);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}