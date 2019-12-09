using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Tasks
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Task/Wait/FuncAction Get Seconds")]
    [NodeWidth(300)]
    public abstract class AWaitNode_GetSecondsNode:ANPBehaveNode<Wait>
    {
        [SerializeField]
        private float _randomVariance;

        protected override Wait GetOutValue()
        {
            return new Wait(GetSeconds,_randomVariance);
        }

        protected abstract float GetSeconds();
    }
}