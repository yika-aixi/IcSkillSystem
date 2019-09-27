using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SystemGestureDeferMode Value")]
    public partial class SystemGestureDeferModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.iOS.SystemGestureDeferMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.iOS.SystemGestureDeferMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}