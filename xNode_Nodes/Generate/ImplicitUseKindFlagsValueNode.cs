using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ImplicitUseKindFlags Value")]
    public partial class ImplicitUseKindFlagsValueNode:ValueNode
    {
        [SerializeField]
        private JetBrains.Annotations.ImplicitUseKindFlags _value;

        public override Type ValueType { get; } = typeof(JetBrains.Annotations.ImplicitUseKindFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}