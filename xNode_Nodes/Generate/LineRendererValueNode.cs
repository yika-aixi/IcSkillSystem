using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LineRenderer Value")]
    public partial class LineRendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LineRenderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LineRenderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}