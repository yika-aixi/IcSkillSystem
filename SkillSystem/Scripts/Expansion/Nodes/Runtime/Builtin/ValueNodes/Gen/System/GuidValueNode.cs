using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/System/Guid Value")]
    public partial class GuidValueNode:ValueNode<IcVariableGuid>
    {
        [SerializeField]
        private System.Guid _value;
   
        private IcVariableGuid _variableValue = new IcVariableGuid();
   
        protected override IcVariableGuid GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableGuid:ValueInfo<System.Guid>
    {
    }
}