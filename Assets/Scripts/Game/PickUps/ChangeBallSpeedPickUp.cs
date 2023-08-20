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
            Ball[] ballsInGame = LevelService.Instance.GetAllBalls();
            for (int i = 0; i < ballsInGame.Length; i++)
            {
                ballsInGame[i].ChangeSpeed(_speedMultiplier);
            }

         
        }

        #endregion
    }
}