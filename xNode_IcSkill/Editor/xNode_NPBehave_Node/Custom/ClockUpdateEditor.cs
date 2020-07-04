//Create: Icarus
//ヾ(•ω•`)o
//2020-07-05 01:36
//CabinIcarus.IcSkillSystem.xNodeIc.Editor

using System;
using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using UnityEditor;

namespace CabinIcarus.IcSkillSystem.Nodes.Editor.Custom
{
    [CustomEditor(typeof(ClockUpdate))]
    public class ClockUpdateEditor:UnityEditor.Editor
    {
        private ClockUpdate _clock;
        
        private void OnEnable()
        {
            _clock = (ClockUpdate) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            EditorGUILayout.LabelField("Clock Count:",_clock.ClockCount.ToString());
        }
    }
}