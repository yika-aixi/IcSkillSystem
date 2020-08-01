using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ArticulationDofLock Value")]
    public partial class ArticulationDofLockValueNode:ValueNode<IcVariableArticulationDofLock>
    {
        [SerializeField]
        private UnityEngine.ArticulationDofLock _value;
   
        private IcVariableArticulationDofLock _variableValue = new IcVariableArticulationDofLock();
   
        protected override IcVariableArticulationDofLock GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}