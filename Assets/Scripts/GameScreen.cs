using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Arkanoid
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private Transform _healthParentTransform;
        [SerializeField] private GameObject _healthPrefab;
        private readonly List<GameObject> _healthPoints = new();

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            CreateHealth();
            UpdateHealthPoint(GameService.Instance.Health);
            GameService.Instance.OnHPChanged += UpdateHealthPoint;
        }

        private void Update()
        {
            UpdateScore();
        }

        private void OnDestroy()
        {
            GameService.Instance.OnHPChanged -= UpdateHealthPoint;
        }

        #endregion

        #region Private methods

        private void CreateHealth()
        {
            for (int i = 0; i < GameService.Instance.Health; i++)
            {
                GameObject instance = Instantiate(_healthPrefab, _healthParentTransform);
                _healthPoints.Add(instance);
            }
        }

        private void UpdateHealthPoint(int hp)
        {
            for (int i = 0; i < _healthPoints.Count; i++)
            {
                _healthPoints[i].gameObject.SetActive(hp > i);
            }
        }

        private void UpdateScore()
        {
            _scoreLabel.text = $"Score: {GameService.Instance.Score}";
        }

        #endregion
    }
}