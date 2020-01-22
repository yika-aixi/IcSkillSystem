using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/LightType Value")]
    public partial class LightTypeValueNode:ValueNode<IcVariableLightType>
    {
        [SerializeField]
        private UnityEngine.LightType _value;
   
        private IcVariableLightType _variableValue = new IcVariableLightType();
   
        protected override IcVariableLightType GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableLightType:ValueInfo<UnityEngine.LightType>
    {
    }
}