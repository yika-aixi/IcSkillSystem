using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Permission Value")]
    public partial class PermissionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Android.Permission _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Android.Permission);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}