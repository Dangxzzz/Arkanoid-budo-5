using UnityEngine;

namespace Arkanoid
{
    public class ChangeBallSpeedPickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _speedMultipier;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ChangeBallSpeed(_speedMultipier);
        }

        #endregion
    }
}