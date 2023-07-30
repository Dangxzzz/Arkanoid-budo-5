using UnityEngine;

namespace Arkanoid
{
    public class Block : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _hitToDestroy;
        [SerializeField] private int _scoreForDestroy;
        [SerializeField] private Sprite _oneHitSprite;
        [SerializeField] private Sprite _twoHitSprite;
        [SerializeField] private Sprite _threeHitSprite;
        private int _hits;
        private ScoreCounter _scoreCounter;

        #endregion

        #region Properties

        public int ScoreForDestroy => _scoreForDestroy;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _scoreCounter = FindObjectOfType<ScoreCounter>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            _hits++;
            ChangeSprite();
            if (_hits >= _hitToDestroy)
            {
                _scoreCounter.BlockDestroyed(this);
                Destroy(gameObject);
            }
        }

        #endregion

        #region Private methods

        private void ChangeSprite()
        {
            if (_hits == 1)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = _oneHitSprite;
            }
            else if (_hits == 2)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = _twoHitSprite;
            }
            else if (_hits == 3)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = _threeHitSprite;
            }
        }

        #endregion
    }
}