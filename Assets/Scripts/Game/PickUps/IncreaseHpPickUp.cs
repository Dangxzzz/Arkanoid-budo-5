using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class IncreaseHpPickUp : PickUp
    {
        #region Variables

        [SerializeField] private int _count;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            if (GameService.Instance.Health < GameService.Instance.MaxHealth)
            {
                GameService.Instance.ChangeHP(_count);
            }
        }

        #endregion
    }
}