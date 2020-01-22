using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Color32 Value")]
    public partial class Color32ValueNode:ValueNode<IcVariableColor32>
    {
        [SerializeField]
        private UnityEngine.Color32 _value;
   
        private IcVariableColor32 _variableValue = new IcVariableColor32();
   
        protected override IcVariableColor32 GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableColor32:ValueInfo<UnityEngine.Color32>
    {
    }
}