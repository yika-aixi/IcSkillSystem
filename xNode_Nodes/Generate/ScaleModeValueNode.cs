using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/ScaleMode Value")]
    public partial class ScaleModeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ScaleMode _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ScaleMode);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}