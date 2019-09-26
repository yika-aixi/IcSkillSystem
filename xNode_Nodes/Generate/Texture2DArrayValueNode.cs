using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Texture2DArray Value")]
    public partial class Texture2DArrayValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Texture2DArray _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Texture2DArray);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}