using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Arkanoid
{
    public class Ball : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Platform _platform;
        [SerializeField] private Rigidbody2D _rb;
        [SerializeField] private float _constantSpeed;

        private bool _isStarted;
        private Vector3 _offset;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _offset = transform.position - _platform.transform.position;
            GameService.Instance.OnBallFall += SetStartSettingsForBall;
        }

        private void OnDestroy()
        {
            GameService.Instance.OnBallFall -= SetStartSettingsForBall;
        }

        private void Update()
        {
            if (_isStarted)
            {
                return;
            }

            SetStartSettingsForBall();
        }

        private void SetStartSettingsForBall()
        {
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

        #region Private methods

        private void MoveWithPad()
        {
            Vector3 platformPosition = _platform.transform.position;
            platformPosition += _offset;
            transform.position = platformPosition;
        }

        private void StartBall()
        {
            _isStarted = true;
            Vector2 randomDirection = new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(0.5f, 1f))
                .normalized;
            _rb.velocity = randomDirection * _constantSpeed;
        }

        #endregion
    }
}