using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GizmoSubset Value")]
    public partial class GizmoSubsetValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.GizmoSubset _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.GizmoSubset);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}