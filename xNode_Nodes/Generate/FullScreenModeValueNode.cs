using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FullScreenMode Value")]
    public partial class FullScreenModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.FullScreenMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.FullScreenMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}