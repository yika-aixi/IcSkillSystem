using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/Physics2DModule/JointSuspension2D Value")]
    public partial class JointSuspension2DValueNode:ValueNode<ValueInfo<UnityEngine.JointSuspension2D>>
    {
        [SerializeField]
        private UnityEngine.JointSuspension2D _value;
   
        private ValueInfo<UnityEngine.JointSuspension2D> _variableValue;
   
        protected override ValueInfo<UnityEngine.JointSuspension2D> GetTValue()
        {
            _variableValue = _value;
            return _variableValue;
        }
    }
}