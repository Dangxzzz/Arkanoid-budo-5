using UnityEngine;

namespace Arkanoid
{
    public class ChangePlatformSizePickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _scaleToChange;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangePlatformSize(_scaleToChange);
        }

        #endregion
    }
}