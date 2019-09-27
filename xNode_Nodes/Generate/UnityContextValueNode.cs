using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/UnityContext Value")]
    public partial class UnityContextValueNode:ValueNode
    {
        [SerializeField]
        private NPBehave.UnityContext _value;

        public override Type ValueType { get; } = typeof(NPBehave.UnityContext);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}