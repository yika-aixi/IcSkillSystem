//创建者:Icarus
//手动滑稽,滑稽脸
//ヾ(•ω•`)o
//https://www.ykls.app
//2019年09月15日-19:30
//CabinIcarus.SkillSystem.Runtime

using System.Collections.Generic;
using CabinIcarus.SkillSystem.Runtime.Buffs.Systems.Interfaces;
using CabinIcarus.SkillSystem.Scripts.Runtime.Buffs;

namespace Cabin_Icarus.SkillSystem.Scripts.Runtime.Buffs.Systems
{
    public class BuffDriveSystem:IBuffDriveSystem
    {
        private List<IBuffCreateSystem> _createSystems;

        private List<IBuffUpdateSystem> _updateSystems;

        private List<IBuffDestroySystem> _destroySystems;

        public IBuffDriveSystem AddBuffSystem(IBuffSystem buffSystem)
        {
            switch (buffSystem)
            {
                case IBuffCreateSystem buff:
                    _createSystems.Add(buff);
                    break;
                case IBuffUpdateSystem buff:
                    _updateSystems.Add(buff);
                    break;
                case IBuffDestroySystem buff:
                    _destroySystems.Add(buff);
                    break;
            }
            
            return this;
        }
        
        public void Create()
        {
            for (var i = 0; i < _createSystems.Count; i++)
            {
                _createSystems[i].Create();
            }
        }

        public void Execute()
        {
            for (var i = 0; i < _updateSystems.Count; i++)
            {
                _updateSystems[i].Execute();
            }
        }

        public void Destroy()
        {
            for (var i = 0; i < _destroySystems.Count; i++)
            {
                _destroySystems[i].Destroy();
            }
        }
    }
}