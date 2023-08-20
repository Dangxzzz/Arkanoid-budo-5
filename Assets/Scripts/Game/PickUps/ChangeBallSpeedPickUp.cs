using System.Collections.Generic;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeBallSpeedPickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _speedMultiplier;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            List<Ball> allBalls = LevelService.Instance.Balls;
            for (int i = 0; i < allBalls.Count; i++)
            {
                allBalls[i].ChangeSpeed(_speedMultiplier);
            }
        }

        #endregion
    }
}