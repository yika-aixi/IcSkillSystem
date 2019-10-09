using System;
using System.Collections.Generic;
using System.Reflection;

namespace CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils
{
    public static class TypeManager
    {
        private static readonly Dictionary<Type, int> _typeIndexMap;
        private static readonly Dictionary<int, Type> _indexToTypeMap;
        
        static TypeManager()
        {
            _typeIndexMap = new Dictionary<Type, int>();
            _indexToTypeMap = new Dictionary<int, Type>();
            
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            var componentTypeSet = new HashSet<Type>();
            foreach (var assembly in assemblies)
            {
                if (!IsAssemblyReferencingIcSkillSystem(assembly))
                {
                    continue;
                }
                
                var assemblyTypes = assembly.GetTypes();
                
                foreach (var type in assemblyTypes)
                {
                    if (type.ContainsGenericParameters)
                        continue;

                    if (type.IsAbstract)
                        continue;

                    if (type.IsClass || type.IsValueType)
                    {
                        componentTypeSet.Add(type);
                    }
                }
            }
            
            int index = 0;

            foreach (var type in componentTypeSet)
            {
                _typeIndexMap.Add(type,index);
                _indexToTypeMap.Add(index,type);
                ++index;
            }
        }

        /// <summary>
        /// index to Type
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public static Type FindType(int index)
        {
            _indexToTypeMap.TryGetValue(index, out var type);

            return type;
        }
        
        /// <summary>
        /// Type to index
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static int FindTypeIndex(Type type)
        {
            if (!_typeIndexMap.TryGetValue(type, out var index))
            {
                index = -1;
            }

            return index;
        }
        
        private static bool IsAssemblyReferencingIcSkillSystem(Assembly assembly)
        {
            const string entitiesAssemblyName = "CabinIcarus.IcSkillSystem";
            if (assembly.GetName().Name.Contains(entitiesAssemblyName))
                return true;

            var referencedAssemblies = assembly.GetReferencedAssemblies();
            foreach(var referenced in referencedAssemblies)
                if (referenced.Name.Contains(entitiesAssemblyName))
                    return true;
            return false;
        }
    }
}