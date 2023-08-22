using Arkanoid.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.UI
{
    public class LevelsMenu : MonoBehaviour
    {
        #region Variables

        [SerializeField] private Button[] _levelsButton;
        [SerializeField] private Button _backButton;
        private readonly int _sceneOffset = 2;

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            _backButton.onClick.AddListener(OnBackButtonClick);
            _levelsButton[0].onClick.AddListener(() => OnLevelButtonClick(0));
            _levelsButton[1].onClick.AddListener(() => OnLevelButtonClick(1));
            _levelsButton[2].onClick.AddListener(() => OnLevelButtonClick(2));
            _levelsButton[3].onClick.AddListener(() => OnLevelButtonClick(3));
            _levelsButton[4].onClick.AddListener(() => OnLevelButtonClick(4));
        }

        #endregion

        #region Private methods

        private void OnBackButtonClick()
        {
            SceneLoader.Instance.LoadChosenScene(0);
        }

        private void OnLevelButtonClick(int buttonNumber)
        {
            SceneLoader.Instance.LoadChosenScene(buttonNumber + _sceneOffset);
        }

        #endregion
    }
}