using System.Collections.Generic;
using Arkanoid.Services;
using TMPro;
using UnityEngine;

namespace Arkanoid.UI
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

        private void AddHealth()
        {
            GameObject instance = Instantiate(_healthPrefab, _healthParentTransform);
            _healthPoints.Add(instance);
        }

        private void AddHealth(int count)
        {
            for (int i = 0; i < count; i++)
            {
                AddHealth();
            }
        }

        private void CreateHealth()
        {
            for (int i = 0; i < GameService.Instance.Health; i++)
            {
                AddHealth();
            }
        }

        private void UpdateHealthPoint(int hp)
        {
            if (_healthPoints.Count < hp)
            {
                AddHealth(hp - _healthPoints.Count);
            }

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