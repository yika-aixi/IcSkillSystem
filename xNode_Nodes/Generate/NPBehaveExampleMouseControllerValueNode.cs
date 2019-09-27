using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/Project/NPBehaveExampleMouseController Value")]
    public partial class NPBehaveExampleMouseControllerValueNode:ValueNode
    {
        [SerializeField]
        private NPBehaveExampleMouseController _value;

        public override Type ValueType { get; } = typeof(NPBehaveExampleMouseController);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}