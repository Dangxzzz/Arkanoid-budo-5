using UnityEngine;

namespace Arkanoid
{
    public class IncreaseHpPickUp : PickUp
    {
        [SerializeField] private bool _isDecrementHp;
        
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangeHP(_isDecrementHp);
        }

        #endregion
    }
}