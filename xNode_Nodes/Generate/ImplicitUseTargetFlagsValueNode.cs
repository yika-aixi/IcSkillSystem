using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ImplicitUseTargetFlags Value")]
    public partial class ImplicitUseTargetFlagsValueNode:ValueNode
    {
        [SerializeField]
        private JetBrains.Annotations.ImplicitUseTargetFlags _value;

        public override Type ValueType { get; } = typeof(JetBrains.Annotations.ImplicitUseTargetFlags);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}