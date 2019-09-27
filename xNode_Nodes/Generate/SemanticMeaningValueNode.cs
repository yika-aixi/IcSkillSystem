using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SemanticMeaning Value")]
    public partial class SemanticMeaningValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.Speech.SemanticMeaning _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.Speech.SemanticMeaning);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}