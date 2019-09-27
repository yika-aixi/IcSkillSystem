using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/IMGUIModule/ImagePosition Value")]
    public partial class ImagePositionValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ImagePosition _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ImagePosition);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}