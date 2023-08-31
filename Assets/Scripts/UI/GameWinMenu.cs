using System;
using Arkanoid.Services;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arkanoid.UI
{
    public class GameWinMenu : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contextMenu;
        [SerializeField] private TextMeshProUGUI _scoreLabel;
        [SerializeField] private Button _nextLevelButton;

        private void Start()
        {
            _nextLevelButton.onClick.AddListener(OnNextLevelButtonClick);
            LevelService.Instance.OnAllBlocksDestroyed += OnWinLevel;
        }

        private void OnDestroy()
        {
            LevelService.Instance.OnAllBlocksDestroyed -= OnWinLevel;
        }

        private void OnNextLevelButtonClick()
        {
            if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex+1)
            {
                SceneLoader.Instance.LoadChosenScene(0);
            }
            else
            {
                SceneLoader.Instance.LoadNextGameScene(); 
            }
        }

        private void OnWinLevel()
        {
            if (GameService.Instance.IsGameOver)
            {
                return;
            }
            _scoreLabel.text = "Score: " + Convert.ToString(GameService.Instance.Score);
            _contextMenu.SetActive(true);
            PauseService.Instance.SetPause(true);
            
        }

        #endregion
    }
}