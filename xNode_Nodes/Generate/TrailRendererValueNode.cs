using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TrailRenderer Value")]
    public partial class TrailRendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.TrailRenderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.TrailRenderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}