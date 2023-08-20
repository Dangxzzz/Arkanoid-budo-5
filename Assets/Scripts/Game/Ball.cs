using System;
using Arkanoid.Services;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Platform _platform;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _constantSpeed;
        [SerializeField] private float _maxScaleBall = 2.5f;
        [SerializeField] private float _minScaleBall = 0.45f;
        [SerializeField] private float _maxSpeedBall = 18;
        [SerializeField] private float _minSpeedBall = 4;

        private bool _isStarted;
        private Vector3 _offset;
        private readonly int _offsetY = 1;

        #endregion

        #region Events

        public static event Action<Ball> OnCreated;
        public static event Action<Ball> OnDestroyed;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _offset.y = _offsetY;

            PerformStartActions();

            OnCreated?.Invoke(this);
        }

        private void Start()
        {
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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rb.velocity);
        }

        #endregion

        #region Public methods

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

        public Ball Clone()
        {
            Ball clone = Instantiate(this, transform.position, Quaternion.identity);
            clone._isStarted = _isStarted;
            clone._offset = _offset;
            clone._rb.velocity = _rb.velocity;
            return clone;
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