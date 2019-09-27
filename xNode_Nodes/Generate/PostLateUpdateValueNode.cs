using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PostLateUpdate Value")]
    public partial class PostLateUpdateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.PlayerLoop.PostLateUpdate _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.PlayerLoop.PostLateUpdate);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}