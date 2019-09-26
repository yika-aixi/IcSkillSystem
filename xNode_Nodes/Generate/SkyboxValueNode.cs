using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Skybox Value")]
    public partial class SkyboxValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.Skybox _value;

        public override Type ValueType { get; } = typeof(UnityEngine.Skybox);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}