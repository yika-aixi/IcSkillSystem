//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年10月27日-23:19
//CabinIcarus.IcSkillSystem.Expansion.Editor


#if ODIN_INSPECTOR
using System;
using System.Reflection;
using System.Linq;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Entitys;
using Sirenix.OdinInspector.Editor;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Editors.Builtin.Buffs.Unity.Entitys
{
    public class EntityOdinShowID<T>:OdinAttributeProcessor<T> where T : IIcSkSEntity 
    {
        public override void ProcessChildMemberAttributes(
            InspectorProperty parentProperty,
            MemberInfo member,
            List<Attribute> attributes)
        {
            if (member.Name == nameof(IIcSkSEntity.ID))
            {
//                var label = parentProperty.Attributes.FirstOrDefault(x => x.GetType() == typeof(LabelTextAttribute));
                
                attributes.Add(new ShowInInspectorAttribute());
                
//                if (label != null)
//                {
//                    attributes.Add(label);
//                }
            }
            
        }
    }

    public class IcEntityOdingShowID : EntityOdinShowID<IcSkSEntity>
    {
    }
}
#endif