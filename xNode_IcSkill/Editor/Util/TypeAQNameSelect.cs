using System;
using System.Collections.Generic;
using System.Linq;
using CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils;
using UnityEditor;
using UnityEngine;

namespace SkillSystem.xNode_IcSkill.Editor.Util
{
    public static class TypeAQNameSelect
    {
        private static List<string> _types;
        
        public static List<Type> Types;

//        public int SelectIndex;
//        private string _currentAQName;
//
//        public TypeAQNameSelect():this(typeof(object))
//        {
//        }
//        
//        public TypeAQNameSelect(string currentAqName):this(typeof(object),currentAqName)
//        {
//        }
//
//        TypeAQNameSelect(Type baseType,string currentAQName = "")
//        {
//            _types = new List<string>();
//            _currentAQName = currentAQName;
//#if IcEditorFrame
//            _types.AddRange(CabinIcarus.EditorFrame.Utils.TypeUtil.GetFilterSystemAssemblyQualifiedNames(GetBaseType()));
//#else
//            _types.AddRange(AppDomain.CurrentDomain.GetAllTypes()
//                .Where(x=> baseType.IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract)
//                .Select(x=>x.AssemblyQualifiedName));
//#endif
//            if (!string.IsNullOrWhiteSpace(_currentAQName))
//            {
//                SelectIndex = _types.FindIndex(x=> x == _currentAQName);
//            }
//        }  

        [InitializeOnLoadMethod]
        static void _init()
        {
            _types = new List<string>();
            
        #if IcEditorFrame
            _types.AddRange(CabinIcarus.EditorFrame.Utils.TypeUtil.GetFilterSystemAssemblyQualifiedNames(GetBaseType()));
        #else
            _types.AddRange(TypeUtil.UnityRuntimeTypes
            .Where(x=> !x.IsInterface && !x.IsAbstract)
            .Select(x=>x.AssemblyQualifiedName));
        #endif

            Types = _types.Select(x => Type.GetType(x)).ToList();
        }
        
        /// <summary>
        /// AQName 选择框
        /// </summary>
        /// <param name="title"></param>
        /// <param name="options"></param>
        public static string DrawSelectPop(GUIContent title,ref int index,Type[] types,params GUILayoutOption[] options)
        {
            var type = DrawSelectPopType(title, ref index, types, options);

            return type != null ? type.AssemblyQualifiedName : string.Empty;
        }
        
        /// <summary>
        /// Type 选择框
        /// </summary>
        /// <param name="title"></param>
        /// <param name="options"></param>
        public static Type DrawSelectPopType(GUIContent title,ref int index,Type[] types,params GUILayoutOption[] options)
        {
            if (types == null || types.Length == 0)
            {
                EditorGUILayout.LabelField("no any type");
                return null;
            }

            index = EditorGUILayout.Popup(title, index,
                types.Select(x=>x.Name).ToArray(),options);

            return types[index];
        }
    }
}