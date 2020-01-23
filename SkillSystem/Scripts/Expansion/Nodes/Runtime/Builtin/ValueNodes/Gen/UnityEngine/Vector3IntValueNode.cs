using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/Vector3Int Value")]
    public partial class Vector3IntValueNode:ValueNode<IcVariableVector3Int>
    {
        [SerializeField]
        private UnityEngine.Vector3Int _value;
   
        private IcVariableVector3Int _variableValue = new IcVariableVector3Int();
   
        protected override IcVariableVector3Int GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}