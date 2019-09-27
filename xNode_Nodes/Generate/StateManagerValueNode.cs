using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/StateManager Value")]
    public partial class StateManagerValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Expansions.StateManager _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Expansions.StateManager);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}