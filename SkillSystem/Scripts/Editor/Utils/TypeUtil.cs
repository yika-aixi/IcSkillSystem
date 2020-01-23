using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor.Compilation;
using Assembly = System.Reflection.Assembly;
using Object = System.Object;

namespace CabinIcarus.IcSkillSystem.Editor.Utils
{
    public static class TypeUtil
    {
        private static List<Type> _objectTypes = new List<Type>();

        public static IEnumerable<Type> AllTypes => _objectTypes;

        public static IEnumerable<Type> GetRuntimeTypes
        {
            get
            {
                return UnityRuntimeTypes
                        .Append(typeof(byte))
                        .Append(typeof(int))
                        .Append(typeof(float))
                        .Append(typeof(double))
                        .Append(typeof(long))
                        .Append(typeof(bool))
                        .Append(typeof(char))
                        .Append(typeof(string));
            }
        }
        
        public static IEnumerable<Type> GetRuntimeFilterTypes
        {
            get
            {
                return GetRuntimeTypes
                    .Where(x => !x.IsPointer)
                    .Where(x => !typeof(Delegate).IsAssignableFrom(x))
                    .Where(x => !typeof(Exception).IsAssignableFrom(x))
                    .Where(x => !typeof(Attribute).IsAssignableFrom(x))
                    .Where(x => !x.IsGenericType)
                    .Where(x => !x.IsAbstract)
                    .Where(x => x.IsValueType || x.IsEnum ||
                                x.IsClass &&
                                x.GetCustomAttributes().All(y => y is SerializableAttribute) ||
                                typeof(Object).IsAssignableFrom(x));
            }
        }
        
        public static IEnumerable<Type> UnityRuntimeTypes
        {
            get
            {
                List<Type> types = new List<Type>();
                
                var runtimeAssemblies = CompilationPipeline.GetAssemblies(AssembliesType.Player);
                runtimeAssemblies = runtimeAssemblies.Where(x => x.defines.Any(y => y != "UNITY_INCLUDE_TESTS")).ToArray();
               
                
                foreach (Type type in AllTypes)
                {
                    foreach (var x in runtimeAssemblies)
                    {
                        if (x.name == type.Assembly.GetName().Name)
                        {
                            types.Add(type);
                            break;
                        }
                    }
                    
                    if (type.Assembly.GetName().Name.StartsWith("UnityEngine"))
                    {
                        if (!types.Contains(type))
                        {
                            types.Add(type);
                        }
                    }
                }

                return types;
            }
        }

        static TypeUtil()
        {
            _collectValueTyps();
        }

        private static void _collectValueTyps()
        {
            _objectTypes.AddRange(AppDomain.CurrentDomain.GetAllTypes().Where(x => x.IsPublic));
            
            foreach (var type in _objectTypes.ToList())
            {
                _objectTypes.AddRange(type.GetNestedTypes(BindingFlags.Public)
                    .Where(x => !x.IsNestedFamANDAssem));
            }

            _objectTypes = _objectTypes.Distinct().ToList();

            _objectTypes = _objectTypes
                .Where(x => x.CustomAttributes.All(y => !(y.AttributeType == typeof(ObsoleteAttribute))))
                .Where(x =>
                {
                    if (x.DeclaringType == null)
                    {
                        return true;
                    }

                    var result =
                        x.DeclaringType.CustomAttributes.Any(y => y.AttributeType == typeof(ObsoleteAttribute));
                 
                    return !result;
                })
                .ToList();
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


        public static string ConversionTypeAssemblyName(this Type self)
        {
            return ConversionAssemblyName(self.Assembly);
        }
        
        public static string ConversionAssemblyName(this Assembly self)
        {
            var assemblyPath = self.GetName().Name;
            
            assemblyPath = assemblyPath.Replace("Assembly-CSharp", "Project");
                    
            assemblyPath = assemblyPath.Replace("mscorlib", "System");

            return assemblyPath;
        }
    }
}