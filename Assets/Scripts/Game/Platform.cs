using System.Collections.Generic;
using Arkanoid.Services;
using Unity.VisualScripting;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Platform : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _maxPlatformSize = 2.5f;
        [SerializeField] private float _minPlatformSize = 0.45f;
        [SerializeField] private SpriteRenderer _platformSpriteRenderer;

        private Sprite _startSprite;
        private float _currentDuration;
        private Color _startColor;

        private bool _isGlue;

        #endregion

        #region Properties

        private void Awake()
        {
            _startSprite = _platformSpriteRenderer.sprite;
            _startColor = _platformSpriteRenderer.color;
        }

        public void EnableGlueMode(float duration, Sprite gluePlatformSprite, Color gluePlatformColor){
            _currentDuration = duration;
            _isGlue = true;
            _platformSpriteRenderer.sprite = gluePlatformSprite;
            _platformSpriteRenderer.color = gluePlatformColor;
        }
        
        private void Timer()
        {
            if (_currentDuration == 0)
            {
                return;
            }
            else
            {
                if (_currentDuration > 0)
                {
                    _currentDuration -= Time.deltaTime;
                    Debug.Log($"Timer{ _currentDuration}");
                }
                else
                {
                    _isGlue = false;
                    _platformSpriteRenderer.sprite = _startSprite;
                    _platformSpriteRenderer.color = _startColor;
                }
            }
        }


        #endregion

        #region Unity lifecycle

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_isGlue)
            {
                if (other.gameObject.CompareTag(Tags.Ball))
                {
                    Debug.Log("Ball cathed");
                    Ball catchBall = other.gameObject.GetComponent<Ball>();
                    List<Ball> catchBalls = new();
                    catchBalls.Add(catchBall);
                    for (int i=0; i < catchBalls.Count; i++)
                    {
                        catchBalls[i].IsStarted=false;
                    }
                }
            }
        }

        private void Update()
        {
            Timer();
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

        #region Public methods

        public void ChangePlatformSize(float sizeMultiplier)
        {
            Vector3 currentSize = transform.localScale;
            if (currentSize.x >= _maxPlatformSize || currentSize.x <= _minPlatformSize)
            {
                return;
            }

            float newScaleX = currentSize.x * sizeMultiplier;
            Vector3 newScale = transform.localScale;
            newScale.x = newScaleX;
            transform.localScale = newScale;
        }

        #endregion

        #region Private methods

        private void MoveWithBall()
        {
            Vector3 ballPosition = FindObjectOfType<Ball>().transform.position;
            SetPosition(ballPosition);
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