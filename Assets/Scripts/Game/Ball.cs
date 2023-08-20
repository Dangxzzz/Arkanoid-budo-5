using UnityEngine;

namespace Arkanoid.Game
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _constantSpeed;

        private bool _isStarted;
        private Vector3 _offset;
        private readonly int _offsetY = 1;
        [SerializeField] private float _maxScaleBall=2.5f;
        [SerializeField] private float _minScaleBall=0.45f;
        [SerializeField] private float _maxSpeedBall=18;
        [SerializeField] private float _minSpeedBall=4;

        private Platform _platform;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _platform = FindObjectOfType<Platform>();
        }

        private void Start()
        {
            _offset.y = _offsetY;
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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(transform.position, transform.position + (Vector3)_rb.velocity);
        }

        #endregion

        #region Public methods

        public void ResetBall()
        {
            _isStarted = false;
            _rb.velocity = Vector2.zero;
        }

        public void ChangeSpeed(float speedMultiplier)
        {
            Vector2 currentVelocity = _rb.velocity;
            if (currentVelocity.magnitude >= _maxSpeedBall || currentVelocity.magnitude<=_minSpeedBall)
            {
                return;
            }
            _rb.velocity = currentVelocity * speedMultiplier;
        }

        public void ChangeSize(float sizeMultiplier)
        {
            Vector3 currentSize = transform.localScale;
            if (currentSize.x >= _maxScaleBall || currentSize.x<=_minScaleBall)
            {
                return;
            }
            transform.localScale = currentSize*sizeMultiplier;
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

        #endregion
    }
}