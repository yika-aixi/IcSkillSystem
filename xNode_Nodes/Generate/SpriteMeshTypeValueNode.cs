using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpriteMeshType Value")]
    public partial class SpriteMeshTypeValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpriteMeshType _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpriteMeshType);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}