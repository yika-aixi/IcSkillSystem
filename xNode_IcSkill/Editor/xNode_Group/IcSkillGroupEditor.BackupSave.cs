//Create: Icarus
//ヾ(•ω•`)o
//2020-08-03 03:10
//CabinIcarus.IcSkillSystem.xNodeIc.Editor

using UnityEditor;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    public partial class IcSkillGroupEditor
    {
        private double _lastBackupTime;

        void _backupStart()
        {
            _lastBackupTime = EditorApplication.timeSinceStartup;
        }
        
        void _backupHandle()
        {
            if (EditorApplication.timeSinceStartup >= _lastBackupTime + Setting.SaveTime)
            {
                _backup();    
            }
        }

        void _backup()
        {
            _lastBackupTime = EditorApplication.timeSinceStartup;
            
            _saveAsJson($"{Setting.SaveFolder}/{target.name}.Json");
        }
    }
}