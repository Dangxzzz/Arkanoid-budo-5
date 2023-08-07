using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid
{
    public class PauseMenu : MonoBehaviour
    {
        #region Variables

        public static bool IsPausedGame;

        [SerializeField] private GameObject _pauseMenuUI;
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _resumeButton;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            IsPausedGame = false;
            Time.timeScale = 1;
            _mainMenuButton.onClick.AddListener(OnMainMenuButtonClick);
            _resumeButton.onClick.AddListener(OnResumeButtonClick);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (IsPausedGame)
                {
                    Resume();
                }
                else
                {
                    OpenPauseMenu();
                }
            }
        }

        #endregion

        #region Private methods

        private void OnMainMenuButtonClick() { }

        private void OnResumeButtonClick()
        {
            Resume();
        }

        private void OpenPauseMenu()
        {
            _pauseMenuUI.gameObject.SetActive(true);
            Time.timeScale = 0f;
            IsPausedGame = true;
        }

        private void Resume()
        {
            _pauseMenuUI.gameObject.SetActive(false);
            Time.timeScale = 1f;
            IsPausedGame= false;
        }

        #endregion
    }
}