
using UnityEngine;

namespace Arkanoid
{
    public class IncreaseScorePickUp : PickUp
    {
        #region Variables

        [SerializeField] private int _scoreToChange = 10;

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