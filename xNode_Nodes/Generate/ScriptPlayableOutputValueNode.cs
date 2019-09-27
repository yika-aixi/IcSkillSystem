using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/ScriptPlayableOutput Value")]
    public partial class ScriptPlayableOutputValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Playables.ScriptPlayableOutput _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Playables.ScriptPlayableOutput);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}