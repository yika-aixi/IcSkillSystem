using UnityEditor;
using UnityEngine;

namespace CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base
{
    class DefaultSaveAsAssetProcessor:ISaveAsAssetProcessor
    {
        public string GetPath(Object obj)
        {
            return AssetDatabase.GetAssetPath(obj);
        }

        public Object GetAsset(string path)
        {
            return AssetDatabase.LoadAssetAtPath<Object>(path);
        }
    }
}