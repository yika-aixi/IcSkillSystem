using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LineAlignment Value")]
    public partial class LineAlignmentValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LineAlignment _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LineAlignment);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}