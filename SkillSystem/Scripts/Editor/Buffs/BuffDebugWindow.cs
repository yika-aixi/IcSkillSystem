using System.Linq;
using CabinIcarus.IcSkillSystem.Runtime.Buffs;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Systems.Interfaces;
using UnityEditor;
using UnityEngine;
using EditorGUI = UnityEditor.EditorGUI;
using EditorGUILayout = UnityEditor.EditorGUILayout;

namespace  CabinIcarus.IcSkillSystem.Editor
{
    public class BuffDebugWindow : EditorWindow
    {
        public static IBuffManager EntityManager;
        
        [UnityEditor.MenuItem("Icarus/Analysis/IIcSkSEntity Buff")]
        private static void ShowWindow()
        {
            var window = GetWindow<BuffDebugWindow>();

            window.titleContent = new UnityEngine.GUIContent("Buff Analysis");
            window.Show();
        }

        private Vector2 _pos;
        private void OnGUI()
        {
            if (EntityManager == null)
            {
                EditorGUILayout.HelpBox("please set EntityManager -> BuffDebugWindow.EntityManager",
                    MessageType.Warning);
                return;
            }

            var entitys = EntityManager.Entitys;

            EditorGUILayout.LabelField("Entity count:" + entitys.Count);

            EditorGUI.indentLevel++;
            _pos = EditorGUILayout.BeginScrollView(_pos,"box");
            {
                foreach (var entity in entitys)
                {
                    EditorGUILayout.LabelField($"{entity} Buff Count:" +
                                               EntityManager.GetAllBuff(entity).Count());
                }
            }
            EditorGUILayout.EndScrollView();
            EditorGUI.indentLevel--;
            
            Repaint();
        }
    }
}