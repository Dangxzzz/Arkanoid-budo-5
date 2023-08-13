using Unity.VisualScripting;
using UnityEngine;

namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        #region Variables
        [Header("Components")]
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [Header("Configs")]
        
        [SerializeField] private int _hp;
        [SerializeField] private int _score;
        [SerializeField] private bool _isInvisible;
        [Header("Visual")]
        [SerializeField] private Sprite[] _sprites;

        private int _hits;

        #endregion


        #region Unity lifecycle
        
        private void Start()
        {
            if (_isInvisible)
            {
                _spriteRenderer.SetAlpha(0);
            }
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (_isInvisible)
            {
                _isInvisible = false;
                _spriteRenderer.SetAlpha(1);
                return;
            }
            _hits++;
            ChangeSprite();
            if (_hits >= _hp)
            {
                GameService.Instance.AddScore(_score);
                Destroy(gameObject);
            }
        }

        #endregion

        #region Private methods

        private void ChangeSprite()
        {
            if (_hits <= _sprites.Length)
            {
                _spriteRenderer.sprite = _sprites[_hits-1];
            }
        }

        #endregion
    }
}