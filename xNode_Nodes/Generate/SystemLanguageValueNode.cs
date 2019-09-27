using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SystemLanguage Value")]
    public partial class SystemLanguageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SystemLanguage _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SystemLanguage);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}