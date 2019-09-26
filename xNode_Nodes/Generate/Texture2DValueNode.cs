using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Texture2D Value")]
    public partial class Texture2DValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Texture2D _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Texture2D);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}