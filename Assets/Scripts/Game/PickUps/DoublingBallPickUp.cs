using Arkanoid.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace Arkanoid.Game.PickUps
{
    public class DoublingBallPickUp : PickUp
    {
       [SerializeField] private int _clonesCount;
        
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

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