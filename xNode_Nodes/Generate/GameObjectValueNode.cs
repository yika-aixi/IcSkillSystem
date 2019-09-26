using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/GameObject Value")]
    public partial class GameObjectValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.GameObject _value;

        public override Type ValueType { get; } = typeof(UnityEngine.GameObject);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}