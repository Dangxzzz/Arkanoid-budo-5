using Arkanoid.Services;
using UnityEngine;
using UnityEngine.Serialization;

namespace Arkanoid.Game
{
    public class Platform : MonoBehaviour
    {
        
        [SerializeField] private float _maxPlatformSize=2.5f;
        [SerializeField] private float _minPlatformSize = 0.45f;
            
        #region Unity lifecycle

        private void Update()
        {
            if (PauseService.Instance.IsPaused)
            {
                return;
            }

            if (GameService.Instance.NeedAutoPlay)
            {
                MoveWithBall();
            }
            else
            {
                MoveWithMouse();
            }
        }

        #endregion

        #region Private methods

        private void MoveWithBall()
        {
            Vector3 ballPosition = FindObjectOfType<Ball>().transform.position;
            SetPosition(ballPosition);
        }

        public void ChangePlatformSize(float sizeMultiplier)
        {
            Vector3 currentSize = transform.localScale;
            if (currentSize.x >= _maxPlatformSize || currentSize.x<=_minPlatformSize)
            {
                return;
            }
            float newScaleX = currentSize.x * sizeMultiplier;
            Vector3 newScale = transform.localScale;
            newScale.x = newScaleX;
            transform.localScale = newScale;
        }

        private void MoveWithMouse()
        {
            Vector3 mousePosition = Input.mousePosition;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            SetPosition(worldMousePosition);
        }

        private void SetPosition(Vector3 worldPosition)
        {
            Vector3 currentPosition = transform.position;
            currentPosition.x = worldPosition.x;
            transform.position = currentPosition;
        }

        #endregion
    }
}