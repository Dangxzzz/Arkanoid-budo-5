using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    [RequireComponent(typeof(Collider2D))]
    public class BottomWall : MonoBehaviour
    {
        #region Unity lifecycle

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Ball))
            {
                Ball[] allBalls = LevelService.Instance.GetAllBalls();
                bool isLast = allBalls.Length == 1;
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