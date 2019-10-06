using System;
using System.Collections.Generic;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs;
using CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Buffs.Unity;
using CabinIcarus.IcSkillSystem.Runtime.Buffs.Components;
using UnityEditor;
using UnityEngine;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    public class buff添加删除_缓存 : MonoBehaviour
    {
        private BuffManager _buffManage;
        private Enity _entity;
        
        private void Start()
        {
            _buffManage = new BuffManager();
            _entity = new Enity();
            
            _buffAddAndRemove();

            var buffL = gameObject.AddComponent<BuffEntityLinkComponent>();
        
            buffL.Init(_buffManage,_entity);
        
        }

        [ContextMenu("Add")]
        private void _buffAdd()
        {
            var type = typeof(TestBuff);

            for (int i = 0; i < 5000; i++)
            {
                var i1 = i;
                var buff = _buffManage.CreateAndAddBuff(type, _entity, x => { ((TestBuff) x).name = i1.ToString(); });
            }
        }
        
        [ContextMenu("Add And Remove")]
        private void _buffAddAndRemove()
        {
            var type = typeof(TestBuff);

            for (int i = 0; i < 5000; i++)
            {
                var i1 = i;
                var buff = _buffManage.CreateAndAddBuff(type, _entity, x => { ((TestBuff) x).name = i1.ToString(); });
                _buffManage.RemoveBuffEx(_entity, buff);
            }
        }

        public bool IsPool;

        public bool IsAdd;

        public bool isDebug = false;

        private List<TestBuff> _buffs = new List<TestBuff>();
        
        private void Update()
        {
            if (isDebug)
            {
                if (IsAdd)
                {
                    TestBuff buff;
                    if (IsPool)
                    {
                         buff = _buffManage.CreateAndAddBuff<TestBuff>(_entity, null);
                    }
                    else
                    {
                        buff = new TestBuff();
                        _buffManage.AddBuff(_entity,buff);
                    }
                    
                    _buffs.Add(buff);
                }
                else
                {
                    if (_buffs.Count > 0)
                    {
                        for (var i = _buffs.Count - 1; i >= 0; i--)
                        {
                            var buff = _buffs[i];
                            
                            if (IsPool)
                            {
                                _buffManage.RemoveBuffEx(_entity, buff);
                            }
                            else
                            {
                                _buffManage.RemoveBuff(_entity,buff);
                            }
                        }
                    }
                }
            }
        }
    }


    [CustomEditor(typeof(buff添加删除_缓存))]
    class BTEditor:Editor
    {
        private buff添加删除_缓存 _buff;
        private void OnEnable()
        {
            _buff = (buff添加删除_缓存) target;
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            EditorGUILayout.BeginVertical("box");
            {
            }
            EditorGUILayout.EndVertical();
        }
    }
}