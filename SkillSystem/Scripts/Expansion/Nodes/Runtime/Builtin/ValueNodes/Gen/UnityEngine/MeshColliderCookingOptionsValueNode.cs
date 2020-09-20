using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/MeshColliderCookingOptions Value")]
    public partial class MeshColliderCookingOptionsValueNode:ValueNode<ValueInfo<UnityEngine.MeshColliderCookingOptions>>
    {
        [SerializeField]
        private UnityEngine.MeshColliderCookingOptions _value;
   
        private ValueInfo<UnityEngine.MeshColliderCookingOptions> _variableValue;
   
        protected override ValueInfo<UnityEngine.MeshColliderCookingOptions> GetTValue()
        {
            _variableValue.Value = _value;
            
            return _variableValue;
        }

        public override void OnStart()
        {
            base.OnStart();

            _variableValue = _value;
        }

        public override void OnStop()
        {
            base.OnStop();
            
            _variableValue.Release();

            _variableValue = null;
        }
    }
}