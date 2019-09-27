using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/FixedUpdate Value")]
    public partial class FixedUpdateValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.PlayerLoop.FixedUpdate _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.PlayerLoop.FixedUpdate);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}