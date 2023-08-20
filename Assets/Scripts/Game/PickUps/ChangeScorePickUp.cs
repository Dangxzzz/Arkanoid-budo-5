using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class IncreaseScorePickUp : PickUp
    {
        #region Variables

        [SerializeField] private int _scoreToChange;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangeScore(_scoreToChange);
        }

        #endregion
    }
}