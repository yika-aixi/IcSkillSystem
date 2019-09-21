using System;
using NPBehave;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node
{
    [CreateNodeMenu("CabinIcarus/IcSkillSystem/Behave Nodes/Clock/Get UnityContext")]
    public class UnityContextClockNode:ClockNode
    {
        protected override void CreateNode()
        {
            
#if UNITY_EDITOR
            //没有播放,不执行
            if (!Application.isPlaying)
            {
                return;
            }
#endif
            
            Clock = UnityContext.GetClock(); 
        }
    }
}