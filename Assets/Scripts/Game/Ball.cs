using UnityEngine;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _constantSpeed;

        private bool _isStarted;
        private Vector3 _offset;
        private readonly int _offsetY = 1;

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

        public void SetNewSpeed(float speedIncrease)
        {
            Vector2 currentVelocity = _rb.velocity;
            _rb.velocity = currentVelocity * speedIncrease;
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