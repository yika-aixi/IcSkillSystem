using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CoveredSequencePoint Value")]
    public partial class CoveredSequencePointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TestTools.CoveredSequencePoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TestTools.CoveredSequencePoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}