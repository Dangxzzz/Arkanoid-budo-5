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
        [SerializeField] private Button _mainMenuButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _contentObject.SetActive(false);
        }

        private void Start()
        {
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
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
            PauseService.Instance.TogglePause();
            _contentObject.SetActive(true);
            _scoreLabel.text = "Score: " + Convert.ToString(GameService.Instance.Score);
        }

        private void OnMainMenuButtonClick()
        {
            SceneLoader.Instance.LoadChosenScene(0);
        }

        private void OnRetryButtonClick()
        {
            GameService.Instance.RestartLevel();
        }

        #endregion
    }
}