using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Com;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/FuncAction Get Seconds")]
    public class WaitNode_GetSecondsFunc:ANPBehaveNode
    {
        [SerializeField,Input(ShowBackingValue.Never,ConnectionType.Override,TypeConstraint.Inherited,typeof(IFuncExecuteNode<float>))]
        private ANPNode _getSeconds;

        [SerializeField]
        private float _randomVariance;

        protected override void CreateNode()
        {
            IFuncExecuteNode<float> getSeconds = ( IFuncExecuteNode<float>) GetInputValue(nameof(_getSeconds), _getSeconds);
            
            Node = new Wait(getSeconds.Execute,_randomVariance);
        }
    }
}