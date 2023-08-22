using System.Collections.Generic;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class Platform : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _maxPlatformSize = 2.5f;
        [SerializeField] private float _minPlatformSize = 0.45f;
        [SerializeField] private SpriteRenderer _platformSpriteRenderer;
        private readonly List<Ball> _catchBalls = new();
        private float _currentDuration;

        private bool _isGlue;
        private Color _startColor;

        private Sprite _startSprite;

        #endregion

        #region Properties

        public List<Ball> CatchBalls => _catchBalls;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _startSprite = _platformSpriteRenderer.sprite;
            _startColor = _platformSpriteRenderer.color;
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

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_isGlue)
            {
                if (other.gameObject.CompareTag(Tags.Ball))
                {
                    Ball catchBall = other.gameObject.GetComponent<Ball>();
                    _catchBalls.Add(catchBall);
                    for (int i = 0; i < _catchBalls.Count; i++)
                    {
                        _catchBalls[i].OffsetX = _catchBalls[i].transform.position.x - transform.position.x;
                        _catchBalls[i].IsStarted = false;
                    }
                }
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

        public void EnableGlueMode(float duration, Sprite gluePlatformSprite, Color gluePlatformColor)
        {
            _currentDuration = duration;
            _isGlue = true;
            _platformSpriteRenderer.sprite = gluePlatformSprite;
            _platformSpriteRenderer.color = gluePlatformColor;
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

        private void Timer()
        {
            if (_currentDuration == 0)
            {
                return;
            }

            if (_currentDuration > 0)
            {
                _currentDuration -= Time.deltaTime;
            }
            else
            {
                _isGlue = false;
                _platformSpriteRenderer.sprite = _startSprite;
                _platformSpriteRenderer.color = _startColor;
            }
        }

        #endregion
    }
}