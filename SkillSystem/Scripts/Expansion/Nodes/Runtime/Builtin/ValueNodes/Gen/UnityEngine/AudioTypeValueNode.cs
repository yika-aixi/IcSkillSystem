using System;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_Nodes
{
    [CreateNodeMenu("CabinIcarus/Nodes/UnityEngine/CoreModule/AudioType Value")]
    public partial class AudioTypeValueNode:ValueNode<IcVariableAudioType>
    {
        [SerializeField]
        private UnityEngine.AudioType _value;
   
        private IcVariableAudioType _variableValue = new IcVariableAudioType();
   
        protected override IcVariableAudioType GetTValue()
        {
            _variableValue.Value = _value;
            return _variableValue;
        }
    }
}