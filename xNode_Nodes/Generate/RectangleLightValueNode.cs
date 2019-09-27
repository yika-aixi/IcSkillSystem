using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/RectangleLight Value")]
    public partial class RectangleLightValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Experimental.GlobalIllumination.RectangleLight _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Experimental.GlobalIllumination.RectangleLight);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}