using System;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/CreateSceneParameters Value")]
    public partial class CreateSceneParametersValueNode:ValueNode
    {
        [SerializeField]
        private UnityEngine.SceneManagement.CreateSceneParameters _value;

        public override Type ValueType { get; } = typeof(UnityEngine.SceneManagement.CreateSceneParameters);
        
        protected override object GetOutValue()
        {
            return _value;
        }
    }
}