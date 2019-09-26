using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/InputLegacyModule/IMECompositionMode Value")]
    public partial class IMECompositionModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.IMECompositionMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.IMECompositionMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}