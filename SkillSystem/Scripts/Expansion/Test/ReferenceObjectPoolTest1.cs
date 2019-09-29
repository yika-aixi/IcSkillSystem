using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IcSkillSystem.SkillSystem.Scripts.Expansion.Runtime.Builtin.Utils;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Profiling;

namespace IcSkillSystem.SkillSystem.Expansion.Tests
{
    class testObj
    {
        
    }
    /// <summary>
    /// 对象创建及归还
    /// </summary>
    public class ReferenceObjectPoolTest1
    {
        private ReferenceObjectPool _pool;
        private List<testObj> _objs;
        
        [SetUp]
        public void Init()
        {
            _pool = new ReferenceObjectPool();
            _objs = new List<testObj>();
            _pool.RecedeCache = true;
        }

        /// <summary>
        /// 对象创建
        /// </summary>
        [Test]
        public void 创建500()
        {
            for (int i = 0; i < 500; i++)
            {
                var testObj = _pool.GetObject<testObj>();
                _objs.Add(testObj);
            }

            Assert.True(_pool[typeof(testObj),true].Count == 500);
        } 
        
        
        /// <summary>
        /// 对象归还
        /// </summary>
        [Test]
        public void 创建500归还200()
        {
            for (int i = 0; i < 500; i++)
            {
                var testObj = _pool.GetObject<testObj>();
                _objs.Add(testObj);
            }
            
            for (int i = 0; i < 200; i++)
            {
                _pool.Recede(_objs[i]);
            }
            Assert.True(_pool[typeof(testObj),true].Count == 300);
            Assert.True(_pool[typeof(testObj),false].Count == 200);
        } 
        
        [Test]
        public void 一边创建一边归还()
        {
            var startMemory = GC.GetTotalMemory(true);
            for (int i = 0; i < 500; i++)
            {
                var testObj = _pool.GetObject<testObj>();
                _pool.Recede(testObj);
            }
            var endMemory = GC.GetTotalMemory(false);
            Debug.Log($"{startMemory} and {endMemory} = {(endMemory - startMemory)}");
            Assert.GreaterOrEqual(_pool[typeof(testObj)].Count, 1);
            Assert.GreaterOrEqual(_pool[typeof(testObj), false].Count, 1);
        } 
        
        [Test]
        public void 线程1个创建1个归还()
        {
            for (int i = 0; i < 500; i++)
            {
                var testObj = _pool.GetObject<testObj>();
                _objs.Add(testObj);
                Task.Run(() =>
                {
                    var index = _objs.Count - 1;
                    _pool.Recede(_objs[index]);
                    _objs.RemoveAt(index);
                });
            }
            
            Assert.GreaterOrEqual(_pool[typeof(testObj)].Count, 1);
            Assert.GreaterOrEqual(_pool[typeof(testObj), false].Count, 1);
        } 
        
        [Test]
        public async void 线程3个创建1个归还()
        {
            var startMemory = GC.GetTotalMemory(true);

            var task1 = Task.Run(() =>
            {
                for (int i = 0; i < 500; i++)
                {
                    var testObj = _pool.GetObject<testObj>();
                    _objs.Add(testObj);
                }
            });
            
            for (int i = 0; i < 500; i++)
            {
                var testObj = _pool.GetObject<testObj>();
                _objs.Add(testObj);
                var task3 = Task.Run(() =>
                {
                    var index = _objs.Count - 1;
                    _pool.Recede(_objs[index]);
                    _objs.RemoveAt(index);
                });
            }
            
            var task2 = Task.Run(() =>
            {
                for (int i = 0; i < 500; i++)
                {
                    var testObj = _pool.GetObject<testObj>();
                    _objs.Add(testObj);
                }
            });

            await task1;
            
            await task2;
            
            var endMemory = GC.GetTotalMemory(false);
            Debug.LogError($"{startMemory} and {endMemory} = {(endMemory - startMemory)}");
            
            Assert.GreaterOrEqual(_pool[typeof(testObj)].Count, 1001);
            Assert.GreaterOrEqual(_pool[typeof(testObj), true].Count, 1001);
        } 
        
        [Test]
        public async void 创建10001()
        {
            var startMemory = GC.GetTotalMemory(true);

            for (int i = 0; i < 10001; i++)
            {
                var testObj = new testObj();
                _objs.Add(testObj);
            }
            
            var endMemory = GC.GetTotalMemory(false);
            Debug.Log($"{startMemory} and {endMemory} = {(endMemory - startMemory)}");
            Assert.True(true);
        } 
        
        [Test]
        public async void 创建10001_Pool()
        {
            var startMemory = GC.GetTotalMemory(true);
            var type = typeof(testObj);
            _pool.AddObjectToPool(new testObj(), false);
            for (int i = 0; i < 10001; i++)
            {
                var test = _pool.GetObject(type);

                if (i % 3 != 0)
                {
                    _pool.Recede(test);
                }
            }
            var endMemory = GC.GetTotalMemory(false);
            Debug.Log($"{startMemory} and {endMemory} = {(endMemory - startMemory)}");
            Assert.True(true);
        } 
    }
}