//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年10月16日-01:45
//CabinIcarus.IcSkillSystem.Expansion.Editor

using CabinIcarus.IcSkillSystem.Editor;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;

namespace CabinIcarus.IcSkillSystem.Expansion.Editors.Builtin.Buffs
{
    public class IcSkSEntityBuffDebugWindow:ABuffDebugWindow<IIcSkSEntity>
    {
        [UnityEditor.MenuItem("Icarus/Analysis/IIcSkSEntity Buff")]
        private static void ShowWindow()
        {
            var window = GetWindow<IcSkSEntityBuffDebugWindow>();

            window.titleContent = new UnityEngine.GUIContent("Buff Analysis");
            window.Show();
        }
    }
}