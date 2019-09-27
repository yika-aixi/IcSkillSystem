using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FogMode Value")]
    public partial class FogModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FogMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FogMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}