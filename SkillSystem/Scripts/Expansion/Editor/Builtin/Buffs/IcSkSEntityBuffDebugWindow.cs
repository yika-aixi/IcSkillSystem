//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年10月16日-01:45
//CabinIcarus.IcSkillSystem.Expansion.Editor

using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using DefaultNamespace;

namespace CabinIcarus.IcSkillSystem.Expansion.Editors.Builtin.Buffs.Unity.Buffs
{
    public class IcSkSEntityBuffDebugWindow:ABuffDebugWindow<IcSkSEntity>
    {
        [UnityEditor.MenuItem("Icarus/Analysis/IcSkSEntity Buff")]
        private static void ShowWindow()
        {
            var window = GetWindow<IcSkSEntityBuffDebugWindow>();

            window.titleContent = new UnityEngine.GUIContent("Buff Analysis");
            window.Show();
        }
    }
}