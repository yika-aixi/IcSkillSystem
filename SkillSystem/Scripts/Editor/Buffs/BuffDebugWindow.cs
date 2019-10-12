using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using EditorGUI = UnityEditor.EditorGUI;
using EditorGUILayout = UnityEditor.EditorGUILayout;

namespace DefaultNamespace
{
    public class BuffDebugWindow : UnityEditor.EditorWindow
    {
        public static IIcSkSEntityManager<IBuffManager<IIcSkSEntity>,IIcSkSEntity> EntityManager;
        
        [UnityEditor.MenuItem("Icarus/Analysis/Buff")]
        private static void ShowWindow()
        {
            var window = GetWindow<BuffDebugWindow>();
            window.titleContent = new UnityEngine.GUIContent("Buff Analysis");
            window.Show();
        }

        private void OnGUI()
        {
            var entitys = EntityManager.Entitys;
            
            EditorGUILayout.LabelField("Entity count:" + entitys.Count);

            EditorGUI.indentLevel++;
            foreach (var entity in entitys)
            {
                EditorGUILayout.LabelField($"{entity} Buff Count:" + EntityManager.BuffManager.GetAllBuff(entity).Count());
            }
            EditorGUI.indentLevel--;
        }
    }
}