using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/AndroidActivityIndicatorStyle Value")]
    public partial class AndroidActivityIndicatorStyleValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.AndroidActivityIndicatorStyle _value;

        public override Type ValueType { get; } = typeof(UnityEngine.AndroidActivityIndicatorStyle);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}