using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector4 Value")]
    public partial class Vector4ValueNode:ValueNode<IcVariableVector4>
    {
        [SerializeField]
        private UnityEngine.Vector4 _value;
   
        private IcVariableVector4 _variableValue = new IcVariableVector4();
   
        protected override IcVariableVector4 GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
    
    [Serializable]
    public class IcVariableVector4:ValueInfo<UnityEngine.Vector4>
    {
    }
}