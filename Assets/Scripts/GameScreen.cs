using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arkanoid
{
    public class GameScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private TMP_Text _scoreLabel;
        [SerializeField] private List<GameObject> _healthPoints;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            UpdateHealthPoint();
            GameService.Instance.OnBallFall += UpdateHealthPoint;
        }

        private void OnDestroy()
        {
            GameService.Instance.OnBallFall -= UpdateHealthPoint;
        }

        private void Update()
        {
            UpdateScore();
        }

        #endregion

        #region Private methods

        private void UpdateScore()
        {
            _scoreLabel.text = $"Score: {GameService.Instance.Score}";
        }

        private void UpdateHealthPoint()
        {
            switch (GameService.Instance.RemovedHealth)
            {
                case 0:
                    _healthPoints[0].gameObject.SetActive(true);
                    _healthPoints[1].gameObject.SetActive(true);
                    _healthPoints[2].gameObject.SetActive(true);
                    break;
                case 1:
                    _healthPoints[0].gameObject.SetActive(true);
                    _healthPoints[1].gameObject.SetActive(true);
                    _healthPoints[2].gameObject.SetActive(false);
                    break;
                case 2:
                    _healthPoints[0].gameObject.SetActive(true);
                    _healthPoints[1].gameObject.SetActive(false);
                    _healthPoints[2].gameObject.SetActive(false);
                    break;
                case 3:
                    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                    GameService.Instance.RemovedHealth = 0;
                    GameService.Instance.Score = 0;
                    break;
            }
        }

        #endregion
    }
}