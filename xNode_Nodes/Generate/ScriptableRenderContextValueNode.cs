using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ScriptableRenderContext Value")]
    public partial class ScriptableRenderContextValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.ScriptableRenderContext _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.ScriptableRenderContext);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}