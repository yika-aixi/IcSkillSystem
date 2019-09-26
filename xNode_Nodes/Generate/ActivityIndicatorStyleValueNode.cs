using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ActivityIndicatorStyle Value")]
    public partial class ActivityIndicatorStyleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.iOS.ActivityIndicatorStyle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.iOS.ActivityIndicatorStyle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}