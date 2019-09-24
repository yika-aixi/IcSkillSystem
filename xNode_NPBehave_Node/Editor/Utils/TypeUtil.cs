using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace CabinIcarus.IcSkillSystem.Editor.xNode_NPBehave_Node.Utils
{
    public static class TypeUtil
    {
        private static List<Type> _objectTypes = new List<Type>();

        public static IEnumerable<Type> AllTypes => _objectTypes;
        
        public static IEnumerable<Type> RuntimeTypes => _objectTypes.Where(x=>!x.Assembly.FullName.Contains("Editor"));

        static TypeUtil()
        {
            _collectValueTyps();
        }

        private static void _collectValueTyps()
        {
            _objectTypes.AddRange(AppDomain.CurrentDomain.GetAllTypes().Where(x => x.IsPublic));
        }
        
        public static Type[] GetAllTypes(this AppDomain appDomain)
        {
            return appDomain.GetAssemblies().GetAllTypes();
        }
        
        public static Type[] GetAllTypes(this IEnumerable<Assembly> assemblies)
        {
            List<Type> typeList = new List<Type>();
            foreach (Assembly assembly in assemblies)
            {
                try
                {
                    typeList.AddRange((IEnumerable<Type>) assembly.GetTypes());
                }
                catch (ReflectionTypeLoadException ex)
                {
                    typeList.AddRange(((IEnumerable<Type>) ex.Types).Where<Type>((Func<Type, bool>) (type => type != null)));
                }
            }
            return typeList.ToArray();
        }
    }
}