using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MeshRenderer Value")]
    public partial class MeshRendererValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MeshRenderer _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MeshRenderer);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}