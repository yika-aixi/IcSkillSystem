using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ConfidenceLevel Value")]
    public partial class ConfidenceLevelValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.Speech.ConfidenceLevel _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.Speech.ConfidenceLevel);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}