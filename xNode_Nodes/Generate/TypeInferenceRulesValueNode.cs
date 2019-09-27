using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/TypeInferenceRules Value")]
    public partial class TypeInferenceRulesValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngineInternal.TypeInferenceRules _value;

        public override Type ValueType { get; } = typeof(UnityEngineInternal.TypeInferenceRules);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}