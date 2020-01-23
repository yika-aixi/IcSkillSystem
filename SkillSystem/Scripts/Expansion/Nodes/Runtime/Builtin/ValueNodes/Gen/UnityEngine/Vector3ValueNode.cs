using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector3 Value")]
    public partial class Vector3ValueNode:ValueNode<IcVariableVector3>
    {
        [SerializeField]
        private UnityEngine.Vector3 _value;
   
        private IcVariableVector3 _variableValue = new IcVariableVector3();
   
        protected override IcVariableVector3 GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}