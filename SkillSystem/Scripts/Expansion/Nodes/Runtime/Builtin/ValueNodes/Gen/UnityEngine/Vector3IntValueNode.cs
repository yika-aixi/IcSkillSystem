using System;
using UnityEngine;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;

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
    
    [Serializable]
    public class IcVariableVector3Int:ValueInfo<UnityEngine.Vector3Int>
    {
    }
}