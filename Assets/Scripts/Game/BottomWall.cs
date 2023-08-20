using System.Collections.Generic;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    [RequireComponent(typeof(Collider2D))]
    public class BottomWall : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Ball))
            {
                List<Ball> allBalls = LevelService.Instance.Balls;
                bool isLast = allBalls.Count == 1;
                if (isLast)
                {
                    GameService.Instance.ChangeHP(-1);
                    GameService.Instance.ResetBall();
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
            else
            {
                Destroy(other.gameObject);
            }
        }

        #endregion
    }
}