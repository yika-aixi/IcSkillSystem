//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:41
//Assembly-CSharp

using System;
using System.Reflection;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using UnityEngine;
using XNode;
using XNodeEditor;

namespace CabinIcarus.IcSkillSystem.xNode_Group.Editor
{
    [CustomNodeGraphEditor(typeof(IcSkillGroup),"CabinIcarus.IcSkillSystem")]
    public class IcSkillGroupEditor:NodeGraphEditor
    {
        private string _noInputNPBehaveNode = "No Input NPBehave Node";

        public override string GetNodeMenuName(Type type)
        {
            return typeof(IIcSkillSystemNode).IsAssignableFrom(type) ? base.GetNodeMenuName(type) : null;
        }

        public override NodeEditorPreferences.Settings GetDefaultPreferences()
        {
            var settings = base.GetDefaultPreferences();
            
            settings.typeColors.Add(_noInputNPBehaveNode,Color.yellow);
            
            return settings;
        }

        //todo 先用它的这样的写法吧,后续改为在Node自定义编辑中处理
        public override string GetPortTooltip(NodePort port)
        {
            var tooltip = base.GetPortTooltip(port);

            var node = port.node;
            
            var attrs = node.GetType().GetField(port.fieldName,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                ?.GetCustomAttributes(typeof(APortTooltipAttribute), false);

            if (attrs == null || attrs.Length == 0)
            {
                attrs = node.GetType().GetProperty(port.fieldName,BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                    ?.GetCustomAttributes(typeof(APortTooltipAttribute), false);
            }
            
            if (attrs != null && attrs.Length == 1)
            {
                if (attrs[0] is PortTooltipAttribute tooltipAttribute)
                {
                    tooltip = string.IsNullOrEmpty(tooltipAttribute.Tooltip) ? tooltip : tooltipAttribute.Tooltip;
                }

                if (attrs[0] is PortTooltipMethodOrPropertyGetAttribute tooltipAttribute1)
                {
                    var method = node.GetType().GetMethod(tooltipAttribute1.MethodOrPropertyName,BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                    if (method != null)
                    {
                        if (method.ReturnType != typeof(string))
                        {
                            throw new ArgumentException($"{tooltipAttribute1.MethodOrPropertyName} Method return type need is {typeof(string)}");
                        }

                        tooltip = (string) method.Invoke(node,null);
                    }
                    else
                    {
                        var property = node.GetType().GetProperty(tooltipAttribute1.MethodOrPropertyName,BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

                        if (property != null)
                        {
                            if (property.PropertyType != typeof(string))
                            {
                                throw new ArgumentException($"{tooltipAttribute1.MethodOrPropertyName} Property type need is {typeof(string)}");
                            }

                            tooltip = (string) property.GetValue(node);
                        }
                    } 
                }
            }

            return tooltip;
        }
    }
}