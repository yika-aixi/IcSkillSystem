//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月19日-21:41
//Assembly-CSharp

using System;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node;
using CabinIcarus.IcSkillSystem.Runtime.xNode_NPBehave_Node.Attributes;
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
            return typeof(INPBehaveNode).IsAssignableFrom(type) ? base.GetNodeMenuName(type) : null;
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

            var attrs = node.GetType().GetCustomAttributes(typeof(PortTooltipAttribute), false);

            if (attrs.Length == 1)
            {
                var tooltipAttribute = ((PortTooltipAttribute) attrs[0]);

                if (port.IsInput)
                {
                    tooltip = string.IsNullOrEmpty(tooltipAttribute.InputTooltip) ? tooltip : tooltipAttribute.InputTooltip;
                }
                else
                {
                    tooltip = string.IsNullOrEmpty(tooltipAttribute.OutputTooltip) ? tooltip : tooltipAttribute.OutputTooltip;
                }
            }

            return tooltip;
        }
    }
}