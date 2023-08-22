using Arkanoid.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.UI
{
    public class StartScene : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _exitGameButton;
        [SerializeField] private Slider _soundSlider;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _startGameButton.onClick.AddListener(OnStartGameButtonClick);
            _exitGameButton.onClick.AddListener(OnExitButtonClick);
        }

        #endregion

        #region Private methods

        private void OnExitButtonClick()
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
        }

        private void OnStartGameButtonClick()
        {
            SceneLoader.Instance.LoadChosenScene(1);
        }

        #endregion
    }
}