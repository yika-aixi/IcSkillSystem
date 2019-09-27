using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/SynchronisationStage Value")]
    public partial class SynchronisationStageValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Rendering.SynchronisationStage _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Rendering.SynchronisationStage);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}