using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(Collider2D))]
    public class BottomWall : MonoBehaviour
    {
        #region Unity lifecycle

        private bool _isLastBall;
        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void Start()
        {
            LevelService.Instance.OnAllBallsDestroyed +=IsLastBall;
        }
        
        private void OnDestroy()
        {
            LevelService.Instance.OnAllBallsDestroyed -=IsLastBall;
        }

        public void IsLastBall(bool isLast)
        {
            _isLastBall = isLast;
        }
        
        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Ball))
            {
                if (_isLastBall)
                {
                    GameService.Instance.DecrementHP();
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