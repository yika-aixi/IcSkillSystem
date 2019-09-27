using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Initialization Value")]
    public partial class InitializationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.PlayerLoop.Initialization _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.PlayerLoop.Initialization);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}