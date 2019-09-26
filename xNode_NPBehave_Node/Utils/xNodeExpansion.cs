using System;
using UnityEngine;
using XNode;

namespace SkillSystem.xNode_NPBehave_Node.Utils
{
    public static class xNodeExpansion
    {
        /// <summary>
        /// 动态输入创建类型实例
        /// </summary>
        /// <param name="self"></param>
        /// <param name="instanceType"></param>
        /// <returns></returns>
        public static object DynamicInputCreateInstance(this Node self, Type instanceType,params object[] args)
        {
            //todo 断言保护
            //
            
            var ins = Activator.CreateInstance(instanceType,args);

            foreach (var dynamicInput in self.DynamicInputs)
            {
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