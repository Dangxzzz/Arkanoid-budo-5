using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class ScoreCounter : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TextMeshProUGUI _scoreLabel;
        private int _currentScore;

        #endregion

        #region Public methods

        public void BlockDestroyed(Block block)
        {
            _currentScore += block.ScoreForDestroy;
            _scoreLabel.text = $"Score:{_currentScore}";
        }

        #endregion
    }
}