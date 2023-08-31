using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class DoublingBallPickUp : PickUp
    {
        #region Variables

        [SerializeField] private int _clonesCount;
        [SerializeField] private GameObject _visualEffect;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            Instantiate(_visualEffect, transform.position, Quaternion.identity);
            int ballsCount = LevelService.Instance.Balls.Count;
            for (int i = 0; i < ballsCount; i++)
            {
                Ball ball = LevelService.Instance.Balls[i];
                for (int j = 0; j < _clonesCount; j++)
                {
                    Ball clone = ball.Clone();
                    clone.RandomizeDirection();
                }
            }
        }

        #endregion
    }
}