using UnityEngine;

namespace Arkanoid.Game
{
    public class WallCheck : MonoBehaviour
    {
        #region Variables

        [SerializeField] private float _camHeight;
        [SerializeField] private float _camWidth;

        [Header("Set Dynamically")]
        [SerializeField] private bool _isOnScreen = true;
        [SerializeField] private bool _keepOnScreen = true;

        [Header("Set in Inspector")]
        [SerializeField] private float _radius = 1f;
        
        private bool _offLeft;
        private bool _offRight;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _camHeight = Camera.main.orthographicSize;
            _camWidth = _camHeight * Camera.main.aspect;
        }

        private void LateUpdate()
        {
            Vector3 pos = transform.position;
            _isOnScreen = true;
            _offRight = _offLeft = false;

            if (pos.x > _camWidth - _radius)
            {
                pos.x = _camWidth - _radius;
                _isOnScreen = false;
                _offRight = true;
            }

            if (pos.x < -_camWidth + _radius)
            {
                pos.x = -_camWidth + _radius;
                _isOnScreen = false;
                _offLeft = true;
            }

            _isOnScreen = !(_offRight || _offLeft);
            if (_keepOnScreen && !_isOnScreen)
            {
                transform.position = pos;
                _isOnScreen = true;
                _offRight = _offLeft = false;
            }
        }

        #endregion
    }
}