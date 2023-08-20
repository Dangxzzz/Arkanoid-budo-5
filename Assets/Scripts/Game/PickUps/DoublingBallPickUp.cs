using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class DoublingBallPickUp : PickUp
    {
        [SerializeField] private int _newBallCount;
        
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            Ball ballInGame = FindObjectOfType<Ball>();
            Ball newBall = Instantiate(ballInGame, ballInGame.transform.position, Quaternion.identity);
            newBall.transform.localScale = ballInGame.transform.localScale;
            newBall.StartBall();
        }

        #endregion
    }
}