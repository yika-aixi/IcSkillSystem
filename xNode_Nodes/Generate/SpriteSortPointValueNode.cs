using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SpriteSortPoint Value")]
    public partial class SpriteSortPointValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SpriteSortPoint _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SpriteSortPoint);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}