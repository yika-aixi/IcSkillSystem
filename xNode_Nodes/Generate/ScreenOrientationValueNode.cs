using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ScreenOrientation Value")]
    public partial class ScreenOrientationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ScreenOrientation _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ScreenOrientation);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}