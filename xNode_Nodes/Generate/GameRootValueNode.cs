using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/GameRoot Value")]
    public partial class GameRootValueNode:ValueNode
    {
        [SerializeField]
        private CabinIcarus.IcSkillSystem.Expansions.GameRoot _value;

        public override Type ValueType { get; } = typeof(CabinIcarus.IcSkillSystem.Expansions.GameRoot);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}