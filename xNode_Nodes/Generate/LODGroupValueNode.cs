using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LODGroup Value")]
    public partial class LODGroupValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.LODGroup _value;

        public override Type ValueType { get; } = typeof(UnityEngine.LODGroup);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}