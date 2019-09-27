using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/PlayerLoopSystem Value")]
    public partial class PlayerLoopSystemValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.LowLevel.PlayerLoopSystem _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.LowLevel.PlayerLoopSystem);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}