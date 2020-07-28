//Create: Icarus
//ヾ(•ω•`)o
//2020-07-28 06:52
//Assembly-CSharp

using CabinIcarus.IcAnimationEditor.Runtime;
using CabinIcarus.IcSkillSystem.xNode_Group;
using UnityEngine;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.IcAnimationModule.Runtime
{
    public class UseSkillGraphModule : IAnimationExpansionModule
    {
        private IcSkillGraph _graph;
        private UseSkillGraphModuleData _data;

        public void Execute(GameObject owner, ModuleData moduleData)
        {
            _data = (UseSkillGraphModuleData) moduleData;

            _graph = _data.GetGraph(owner);
        }

        public void Stop()
        {
            _data.StopGraph(_graph);
        }
    }
}