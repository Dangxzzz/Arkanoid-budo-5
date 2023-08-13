using System;
using UnityEngine;

namespace Arkanoid
{
    public class GameService : SingletonMonoBehaviour<GameService>
    {
        #region Variables

        [Header("Auto Play")]
        [SerializeField] private bool _needAutoPlay;
        [Header("Configs")]
        [SerializeField] private int _startHP;

        #endregion

        #region Events

        public event Action<int> OnHPChanged;
        public event Action OnHPOver;

        #endregion

        #region Properties

        public int Health { get; private set; }
        public bool NeedAutoPlay => _needAutoPlay;
        public int Score { get; set; }

        #endregion

        #region Unity lifecycle

        private void Start()
        {
            SetInitHealth();
            LevelService.Instance.OnAllBlocksDestroyed += OnAllBlocksDestroyed;
        }
        
        public void ChangeScore(int value)
        {
            Score = Mathf.Max(0, Score + value);
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

        public void DecrementHP()
        {
            Health--;
            ResetBall();
            OnHPChanged?.Invoke(Health);
            if (Health <= 0)
            {
                OnHPOver?.Invoke();
            }
        }

        public void SetStartParameters()
        {
            SetInitHealth();
            Score = 0;
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

        public void ResetBall()
        {
            FindObjectOfType<Ball>().ResetBall();
        }

        private void SetInitHealth()
        {
            Health = _startHP;
            OnHPChanged?.Invoke(Health);
        }

        #endregion
    }
}