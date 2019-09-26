using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/GUISkin Value")]
    public partial class GUISkinValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GUISkin _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GUISkin);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}