using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/PhysicsModule/ForceMode Value")]
    public partial class ForceModeValueNode:ValueNode<IcVariableForceMode>
    {
        [SerializeField]
        private UnityEngine.ForceMode _value;
   
        private IcVariableForceMode _variableValue = new IcVariableForceMode();
   
        protected override IcVariableForceMode GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableForceMode:ValueInfo<UnityEngine.ForceMode>
    {
    }
}