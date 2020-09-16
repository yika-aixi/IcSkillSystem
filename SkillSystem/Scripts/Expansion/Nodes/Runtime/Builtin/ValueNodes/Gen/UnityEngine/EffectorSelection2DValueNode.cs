using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/EffectorSelection2D Value")]
    public partial class EffectorSelection2DValueNode:ValueNode<ValueInfo<UnityEngine.EffectorSelection2D>>
    {
        [SerializeField]
        private UnityEngine.EffectorSelection2D _value;
   
        private ValueInfo<UnityEngine.EffectorSelection2D> _variableValue;
   
        protected override ValueInfo<UnityEngine.EffectorSelection2D> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}