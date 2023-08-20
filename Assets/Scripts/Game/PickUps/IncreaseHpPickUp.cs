using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class IncreaseHpPickUp : PickUp
    {
        [SerializeField] private int _count;
        
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangeHP(_count);
        }

        #endregion
    }
}