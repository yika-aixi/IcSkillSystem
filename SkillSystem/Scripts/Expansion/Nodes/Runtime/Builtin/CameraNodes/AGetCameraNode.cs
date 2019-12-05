using CabinIcarus.IcSkillSystem.Nodes.Runtime;
using CabinIcarus.IcSkillSystem.Nodes.Runtime.Attributes;
using NPBehave;
using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    public abstract class AGetCameraNode : ANPBehaveNode<Action>
    {
        [Output]
        [PortTooltipMethodOrPropertyGet(nameof(GetCameraTooltip))]
        protected Camera Camera;
        
        protected sealed override Action GetOutValue()
        {
            return new Action(_getMainCamera);
        }

        private void _getMainCamera()
        {
            if (!Camera)
            {
                Camera = GetCamera();
            } 
        }

        protected abstract Camera GetCamera();

        protected virtual string GetCameraTooltip()
        {
            return "Camera";
        }
    }
}