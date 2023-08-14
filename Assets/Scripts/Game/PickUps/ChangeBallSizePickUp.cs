using UnityEngine;

namespace Arkanoid
{
    public class ChangeBallSizePickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _scaleToChange;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            GameService.Instance.ChangeBallSize(_scaleToChange);
        }

        #endregion
    }
}