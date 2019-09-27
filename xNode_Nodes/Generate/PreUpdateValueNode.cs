using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PreUpdate Value")]
    public partial class PreUpdateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.PlayerLoop.PreUpdate _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.PlayerLoop.PreUpdate);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}