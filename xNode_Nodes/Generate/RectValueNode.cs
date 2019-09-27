using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Rect Value")]
    public partial class RectValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rect _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rect);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}