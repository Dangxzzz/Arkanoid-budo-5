using System;
using UnityEngine;

namespace Arkanoid.Services
{
    public class PauseService : SingletonMonoBehaviour<PauseService>
    {
        #region Events

        public event Action<bool> OnPaused;

        #endregion

        #region Properties

        public bool IsPaused { get; private set; }

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                TogglePause();
            }
        }

        #endregion

        #region Public methods

        public void SetPause(bool isPaused)
        {
            IsPaused = isPaused;
            Time.timeScale = IsPaused ? 0 : 1;
            OnPaused?.Invoke(IsPaused);
        }

        public void TogglePause()
        {
            IsPaused = !IsPaused;
            SetPause(IsPaused);
        }

        #endregion
    }
}