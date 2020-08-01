//Create: Icarus
//ヾ(•ω•`)o
//2020-08-01 04:55
//CabinIcarus.IcSkillSystem.Expansion.Nodes.Runtime

using System;
using CabinIcarus.IcFrameWork.IcSkillSystem.SkillSystem.Scripts.Runtime.Attributes;
using CabinIcarus.IcFrameWork.IcSkillSystem.xNode_IcSkill.Base;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using CabinIcarus.IcSkillSystem.SkillSystem.Runtime.Utils;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes.InputNodes
{
    [CreateNodeMenu("CabinIcarus/IcFrameWork/Auto Execute Node/Input/Key Board")]
    public class InputKeyBoardNode:AAutoExecuteNode
    {
        [SerializeField]
        private InputType _inputType;

        [EnumRangeSelect(typeof(KeyCode), (int) KeyCode.Backspace, (int) KeyCode.Menu,"keyboard Key")]
        [SerializeField]
        [PortTooltip("Value processing keyboard key")]
        private KeyCode _code;

        private static InputKeyBoardHook _hook;
        protected override void On_Init()
        {
            base.On_Init();

            if (!_hook)
            {
                var go = new GameObject("IcSkillSystem.Input.Keyboard.Hook");
                go.hideFlags = HideFlags.HideInHierarchy;
                
                DontDestroyOnLoad(go);

                _hook = go.AddComponent<InputKeyBoardHook>();
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

        void _handle(KeyCode code)
        {
            if (code == _code)
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

    class InputKeyBoardHook:MonoBehaviour
    {
        public event Action<KeyCode> OnDonw;
        public event Action<KeyCode> OnUp;
        public event Action<KeyCode> OnHold;

        private void Update()
        {
            for (KeyCode i = KeyCode.Backspace; i <= KeyCode.Menu; i++)
            {
                if (Input.GetKeyDown(i))
                {
                    OnDonw?.Invoke(i);
                }
                else if(Input.GetKeyUp(i))
                {
                    OnUp?.Invoke(i);
                }
                else if (Input.GetKey(i))
                {
                    OnHold?.Invoke(i);
                }

            }
        }
    }
}