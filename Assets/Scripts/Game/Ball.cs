using System;
using Arkanoid.Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private SpriteRenderer _ballSpriteRenderer;
        [SerializeField] private TrailRenderer _ballTrailRenderer;
        [SerializeField] private Platform _platform;
        [SerializeField] private Rigidbody2D _rb;

        [Header("Configs")]
        [SerializeField] private float _constantSpeed;
        [SerializeField] private float _maxScaleBall = 2.5f;
        [SerializeField] private float _minScaleBall = 0.45f;
        [SerializeField] private float _maxSpeedBall = 18;
        [SerializeField] private float _minSpeedBall = 4;
        private LayerMask _blockMask;
        private float _explosiveRadius;
        private bool _isExplosive;

        private bool _isStarted;
        private Vector3 _offset;
        private readonly int _offsetY = 1;
        private Sprite _startBallSprite;
        private Color _startBallTrailColor;

        #endregion

        #region Events

        public static event Action<Ball> OnCreated;
        public static event Action<Ball> OnDestroyed;

        #endregion

        #region Unity lifecycle

        public bool IsStarted
        {
            set
            {
                _isStarted = value;
            }
        }
        
        private void Awake()
        {
            _startBallSprite = _ballSpriteRenderer.sprite;
            _startBallTrailColor = _ballTrailRenderer.startColor;
            _offset.y = _offsetY;

            PerformStartActions();
        }

        private void Start()
        {
            OnCreated?.Invoke(this);
            if (GameService.Instance.NeedAutoPlay)
            {
                StartBall();
            }
        }

        private void Update()
        {
            if (_isStarted)
            {
                return;
            }

            MoveWithPad();

            if (Input.GetMouseButtonDown(0))
            {
                StartBall();
            }
        }

        private void OnDestroy()
        {
            OnDestroyed?.Invoke(this);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_isExplosive)
            {
                if (other.gameObject.CompareTag(Tags.Block))
                {
                    Collider2D[] colliders =
                        Physics2D.OverlapCircleAll(transform.position, _explosiveRadius, _blockMask);

                    foreach (Collider2D col in colliders)
                    {
                        if (col.TryGetComponent(out Block block))
                        {
                            block.ForceDestroy();
                        }
                    }
                    SetStartBallVisual();
                    _isExplosive = false;
                }
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rb.velocity);
        }

        #endregion

        #region Public methods

        // public void ChangeBallVisual(Sprite newSprite, Color newColor)
        // {
        //     ChangeSprite(newSprite);
        //     ChangeTrail(newColor);
        // }

        public void ChangeSize(float sizeMultiplier)
        {
            Vector3 currentSize = transform.localScale;
            if (currentSize.x >= _maxScaleBall || currentSize.x <= _minScaleBall)
            {
                return;
            }

            transform.localScale = currentSize * sizeMultiplier;
        }

        public void ChangeSpeed(float speedMultiplier)
        {
            Vector2 currentVelocity = _rb.velocity;
            if (currentVelocity.magnitude >= _maxSpeedBall || currentVelocity.magnitude <= _minSpeedBall)
            {
                return;
            }

            _rb.velocity = currentVelocity * speedMultiplier;
        }

        public void ChangeSprite(Sprite newSprite)
        {
            _ballSpriteRenderer.sprite = newSprite;
        }

        public void ChangeTrail(Color newColor)
        {
            _ballTrailRenderer.startColor = newColor;
        }

        public Ball Clone()
        {
            Ball clone = Instantiate(this, transform.position, Quaternion.identity);
            clone._isStarted = _isStarted;
            clone._offset = _offset;
            clone._rb.velocity = _rb.velocity;
            return clone;
        }

        public void DisableExplosiveMode()
        {
            _isExplosive = false;
        }

        public void EnableExplosiveMode(float radius, LayerMask blockMask, Sprite explosiveBallSprite, Color explosiveBallTrailColor)
        {
            _isExplosive = true;
            _explosiveRadius = radius;
            _blockMask = blockMask;
            ChangeSprite(explosiveBallSprite);
            ChangeTrail(explosiveBallTrailColor);
        }

        public void RandomizeDirection()
        {
            Vector2 randomDirection = Random.insideUnitCircle.normalized;
            float currentSpeed = _rb.velocity.magnitude;
            _rb.velocity = randomDirection * currentSpeed;
        }

        public void ResetBall()
        {
            MoveWithPad();
            PerformStartActions();
        }

        public void SetStartBallVisual()
        {
           ChangeSprite(_startBallSprite);
           ChangeTrail(_startBallTrailColor);
        }

        public void StartBall()
        {
            _isStarted = true;
            Vector2 randomDirection = new Vector2(Random.Range(-1f, 1f), Random.Range(0.5f, 1f))
                .normalized;
            _rb.velocity = randomDirection * _constantSpeed;
        }

        #endregion

        #region Private methods

        private void MoveWithPad()
        {
            Vector3 platformPosition = _platform.transform.position;
            platformPosition += _offset;
            transform.position = platformPosition;
        }

        private void PerformStartActions()
        {
            _isStarted = false;
            _rb.velocity = Vector2.zero;
        }

        #endregion
    }
}