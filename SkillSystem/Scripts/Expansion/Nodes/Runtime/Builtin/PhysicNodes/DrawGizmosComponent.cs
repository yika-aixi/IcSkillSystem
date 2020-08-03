using UnityEngine;

namespace CabinIcarus.IcSkillSystem.Expansion.Runtime.Builtin.Nodes
{
    internal class DrawGizmosComponent:MonoBehaviour
    {
        public  System.Action OnDraw;
        public  bool          IsOpen;
        private int           _showCount;
        private float         _minTime = 0.2f;
        private float         _curTime;
        private void OnDrawGizmos()
        {
            if (IsOpen || _showCount == -1)
            {
                OnDraw?.Invoke();

                if (_curTime > _minTime)
                {
                    ++_showCount;
                    _curTime = 0;
                }
                else
                {
                    _curTime += Time.deltaTime;
                }
            }
        }

        public void ShowDebug()
        {
            IsOpen     = true;
            _showCount = -1;
        }

        public void HideDebug()
        {
            IsOpen = false;
        }
    }
}