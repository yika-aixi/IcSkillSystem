using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/DictationTopicConstraint Value")]
    public partial class DictationTopicConstraintValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Windows.Speech.DictationTopicConstraint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Windows.Speech.DictationTopicConstraint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}