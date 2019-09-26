using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CubemapArray Value")]
    public partial class CubemapArrayValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.CubemapArray _value;

        public override Type ValueType { get; } = typeof(UnityEngine.CubemapArray);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}