using Unity.VisualScripting;
using UnityEngine;

namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _hp;
        [SerializeField] private int _score;
        [SerializeField] private Sprite[] _sprites;
        [SerializeField] private SpriteRenderer _spriteRenderer;
        [InspectorToggleLeft][SerializeField] private bool _isInvisible;
        private int _hits;

        #endregion

        #region Properties

        public int Score => _score;

        #endregion

        #region Unity lifecycle
        

        private void OnCollisionEnter2D(Collision2D other)
        {
            _hits++;
            ChangeSprite();
            if (_isInvisible)
            {
                _isInvisible = false;
                return;
            }
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
            Debug.Log($"Hits on block: {_hits}");
            if (_hits <= _sprites.Length)
            {
                _spriteRenderer.sprite = _sprites[_hits-1];
            }
        }

        #endregion
    }
}