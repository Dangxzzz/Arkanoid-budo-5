using Arkanoid.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.UI
{
    public class PauseMenu : MonoBehaviour
    {
        #region Variables

        [SerializeField] private GameObject _contentObject;
        [SerializeField] private Button _continueButton;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _contentObject.SetActive(false);
            _continueButton.onClick.AddListener(OnContinueButtonClicked);
        }

        private void Start()
        {
            PauseService.Instance.OnPaused += OnPaused;
        }

        private void OnDestroy()
        {
            PauseService.Instance.OnPaused -= OnPaused;
        }

        #endregion

        #region Private methods

        private void OnContinueButtonClicked()
        {
            PauseService.Instance.TogglePause();
        }

        private void OnPaused(bool isPaused)
        {
            _contentObject.SetActive(isPaused);
        }

        #endregion
    }
}