using System.Collections.Generic;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangeBallSizePickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _sizeMultiplier;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            List<Ball> allBalls = LevelService.Instance.Balls;
            for (int i = 0; i < allBalls.Count; i++)
            {
                allBalls[i].ChangeSize(_sizeMultiplier);
            }
        }

        #endregion
    }
}