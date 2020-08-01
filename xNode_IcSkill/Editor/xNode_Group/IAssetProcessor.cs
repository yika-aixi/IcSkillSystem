//Create: Icarus
//ヾ(•ω•`)o
//2020-08-02 12:09
//CabinIcarus.IcSkillSystem.xNodeIc.Base

using UnityEngine;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base
{
    public interface ISaveAsAssetProcessor
    {
        string GetPath(Object obj);
        
        Object GetAsset(string path);
    }
}