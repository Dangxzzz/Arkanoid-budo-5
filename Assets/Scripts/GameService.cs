using System;

namespace Arkanoid
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Properties

        public event Action OnBallFall;
        public int Score { get; set; }
        public int RemovedHealth { get; set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            LevelService.Instance.OnAllBlocksDestroyed += OnAllBlocksDestroyed;
        }

        private void OnDestroy()
        {
            LevelService.Instance.OnAllBlocksDestroyed -= OnAllBlocksDestroyed;
        }

        #endregion

        #region Public methods

        public void AddScore(int value)
        {
            Score += value;
        }

        #endregion

        #region Private methods

        private void LoadNextLevel()
        {
            SceneLoader.Instance.LoadNextGameScene();
        }

        private void OnAllBlocksDestroyed()
        {
            LoadNextLevel();
        }

        public void RemoveHealth()
        {
            RemovedHealth++;
            OnBallFall?.Invoke();
        }

        #endregion
    }
}