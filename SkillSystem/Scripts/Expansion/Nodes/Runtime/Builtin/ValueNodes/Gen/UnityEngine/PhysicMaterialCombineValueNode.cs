using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/PhysicMaterialCombine Value")]
    public partial class PhysicMaterialCombineValueNode:ValueNode<ValueInfo<UnityEngine.PhysicMaterialCombine>>
    {
        [SerializeField]
        private UnityEngine.PhysicMaterialCombine _value;
   
        private ValueInfo<UnityEngine.PhysicMaterialCombine> _variableValue = new ValueInfo<UnityEngine.PhysicMaterialCombine>();
   
        protected override ValueInfo<UnityEngine.PhysicMaterialCombine> GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}