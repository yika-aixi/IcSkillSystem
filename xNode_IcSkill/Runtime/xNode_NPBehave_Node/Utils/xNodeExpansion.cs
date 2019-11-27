using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using XNode;

namespace CabinIcarus.IcSkillSystem.Nodes.Runtime.Utils
{
    public static class xNodeExpansion
    {
        private const string _ctorArgName = "(ctor arg)";

        public static string GetCtorParameterName(string argName)
        {
            return $"{argName}{_ctorArgName}";
        }

        public static bool IsCtorParameter(string name)
        {
            return name.Contains(_ctorArgName);
        }

        /// <summary>
        /// 动态输入创建类型实例
        /// </summary>
        /// <param name="self"></param>
        /// <param name="instanceType"></param>
        /// <param name="args">如果是空或者个数为0时将会自动寻找第一个默认构造函数进行设置</param>
        /// <returns></returns>
        public static object DynamicInputCreateInstance(this Node self, Type instanceType,params object[] args)
        {
            //todo 断言保护
            
            if (args == null || args.Length == 0)
            {
                var constructors = instanceType.GetConstructors();
                if (constructors.Length > 0)
                {
                    var defaultCtor = constructors[0];
                    List<object> cArg = new List<object>();
                    foreach (var parameterInfo in defaultCtor.GetParameters())
                    {
                         var ctorInput = self.GetInputPort(GetCtorParameterName(parameterInfo.Name));
                         cArg.Add(ctorInput.GetInputValue());
                    }

                    args = cArg.ToArray();
                }
            }
            
            var ins = Activator.CreateInstance(instanceType,args);

            foreach (var dynamicInput in self.DynamicInputs)
            {
                if (IsCtorParameter(dynamicInput.fieldName))
                {
                    continue;
                }
                
                var value = dynamicInput.GetInputValue();

                if (value == null)
                {
                    Debug.LogWarning($"{dynamicInput?.fieldName} 失败 Value 没有连接,跳过");
                    continue;
                }
                
                try
                {
                    var field = instanceType.GetField(dynamicInput.fieldName);
                    if (field != null)
                    {
                        field.SetValue(ins, value);
                        continue;
                    }
                    
                    var property = instanceType.GetProperty(dynamicInput.fieldName);
                    
                    property.SetValue(ins,value);
                }
                catch(SystemException e)
                {
                    Debug.LogError($"{dynamicInput.fieldName} 失败 Value: {value}\n{e}");
                }   
            }

            return ins;
        }
    }
}