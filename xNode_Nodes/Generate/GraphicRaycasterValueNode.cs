using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/UI/GraphicRaycaster Value")]
    public partial class GraphicRaycasterValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.UI.GraphicRaycaster _value;

        public override Type ValueType { get; } = typeof(UnityEngine.UI.GraphicRaycaster);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}