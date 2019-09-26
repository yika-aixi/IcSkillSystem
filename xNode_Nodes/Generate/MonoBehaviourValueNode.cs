using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/MonoBehaviour Value")]
    public partial class MonoBehaviourValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.MonoBehaviour _value;

        public override Type ValueType { get; } = typeof(UnityEngine.MonoBehaviour);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}