using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ScriptableObject Value")]
    public partial class ScriptableObjectValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.ScriptableObject _value;

        public override Type ValueType { get; } = typeof(UnityEngine.ScriptableObject);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}