using Arkanoid.Services;
using UnityEngine;
using UnityEngine.Serialization;

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
            Ball[] ballsInGame = LevelService.Instance.GetAllBalls();
            for (int i = 0; i < ballsInGame.Length; i++)
            {
                ballsInGame[i].ChangeSize(_sizeMultiplier);
            }
        }

        #endregion
    }
}