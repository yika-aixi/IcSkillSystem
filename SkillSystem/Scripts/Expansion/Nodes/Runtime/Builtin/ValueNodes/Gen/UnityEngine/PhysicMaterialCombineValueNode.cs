using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/PhysicMaterialCombine Value")]
    public partial class PhysicMaterialCombineValueNode:ValueNode<IcVariablePhysicMaterialCombine>
    {
        [SerializeField]
        private UnityEngine.PhysicMaterialCombine _value;
   
        private IcVariablePhysicMaterialCombine _variableValue = new IcVariablePhysicMaterialCombine();
   
        protected override IcVariablePhysicMaterialCombine GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}