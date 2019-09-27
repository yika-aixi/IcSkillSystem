using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpritePackingRotation Value")]
    public partial class SpritePackingRotationValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpritePackingRotation _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpritePackingRotation);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}