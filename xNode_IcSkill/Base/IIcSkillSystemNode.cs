using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.xNode_Group;

namespace CabinIcarus.IcSkillSystem
{
    public interface IIcSkillSystemNode
    {
        IcSkillGraph SkillGraph { get; set; }

        void OnInit();

        void OnStart();
        
        void OnStop();

        IEnumerable<string> GetPreloadAssets();
    }
}