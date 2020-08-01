//Create: Icarus
//ヾ(•ω•`)o
//2020-08-01 04:55
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using System;
using CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes.InputNodes
{
    enum ButtonType
    {
        Left   = 0,
        Right  = 1,
        Middle = 2
    }
    
    [CreateNodeMenu("CabinIcarus/IcFrameWork/Auto Execute Node/Input/Mouse")]
    public class InputMouseNode:AAutoExecuteNode
    {
        [SerializeField]
        private InputType _inputType;

        [SerializeField]
        [PortTooltip("Value processing keyboard key")]
        private ButtonType _button;

        private static InputMouseHook _hook;
        protected override void On_Init()
        {
            base.On_Init();

            if (!_hook)
            {
                var go = new GameObject("IcSkillSystem.Input.Keyboard.Hook");
                go.hideFlags = HideFlags.HideInHierarchy;
                
                DontDestroyOnLoad(go);

                _hook = go.AddComponent<InputMouseHook>();
            }
        }

        public override void OnStart()
        {
            base.OnStart();
            
            switch (_inputType)
            {
                case InputType.Down:
                    _hook.OnDonw += _handle;
                    break;
                case InputType.Up:
                    _hook.OnUp += _handle;
                    break;
                case InputType.Hold:
                    _hook.OnHold += _handle;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        void _handle(ButtonType code)
        {
            if (code == _button)
            {
                Execute();
            }
        }

        public override void OnStop()
        {
            base.OnStop();
            
            switch (_inputType)
            {
                case InputType.Down:
                    _hook.OnDonw -= _handle;
                    break;
                case InputType.Up:
                    _hook.OnUp -= _handle;
                    break;
                case InputType.Hold:
                    _hook.OnHold -= _handle;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    class InputMouseHook:MonoBehaviour
    {
        public event Action<ButtonType> OnDonw;
        public event Action<ButtonType> OnUp;
        public event Action<ButtonType> OnHold;

        private void Update()
        {
            for (ButtonType i = ButtonType.Left; i <= ButtonType.Middle; i++)
            {
                if (Input.GetMouseButtonDown((int) i))
                {
                    OnDonw?.Invoke(i);
                }
                else if(Input.GetMouseButtonUp((int) i))
                {
                    OnUp?.Invoke(i);
                }
                else if (Input.GetMouseButton((int) i))
                {
                    OnHold?.Invoke(i);
                }
            }
        }
    }
}