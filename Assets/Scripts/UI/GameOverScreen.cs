using System;
using Arkanoid.Services;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.Ui
{
    public class GameOverScreen : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contentObject;
        [SerializeField] private TextMeshProUGUI _scoreLabel;
        [SerializeField] private Button _retryButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _contentObject.SetActive(false);
        }

        private void Start()
        {
            _retryButton.onClick.AddListener(OnRetryButtonClick);
            GameService.Instance.OnHPOver += OnHpOver;
        }

        private void OnDestroy()
        {
            GameService.Instance.OnHPOver -= OnHpOver;
        }

        #endregion

        #region Private methods

        private void OnHpOver()
        {
            Time.timeScale = 0;
            _contentObject.SetActive(true);
            _scoreLabel.text = "Score: " + Convert.ToString(GameService.Instance.Score);
        }

        private void OnRetryButtonClick()
        {
            Time.timeScale = 1;
            SceneLoader.Instance.ReloadCurrentScene();
            GameService.Instance.SetStartParameters();
        }

        #endregion
    }
}