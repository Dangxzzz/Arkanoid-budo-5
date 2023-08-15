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
        [SerializeField] private int _startHP=3;
        [SerializeField] private Ball _prefabBall;

        #endregion

        #region Events

        public event Action OnCatchHpPickUp;

        public event Action<int> OnHPChanged;
        public event Action OnHPOver;

        #endregion

        #region Properties

        public int Health { get; private set; }
        public bool NeedAutoPlay => _needAutoPlay;
        public int Score { get; set; }

        #endregion

        #region Unity lifecycle

        private void OnEnable()
        {
            SetInitHealth();
        }

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

        public void ChangeBallSize(float scaleToChange)
        {
            Ball[] BallsInGame = LevelService.Instance.GetAllBalls();
            for (int i = 0; i < BallsInGame.Length; i++)
            {
                BallsInGame[i].transform.localScale += new Vector3(scaleToChange, scaleToChange);
            }
        }

        public void ChangeBallSpeed(float speedMultiplier)
        {
            Ball[] BallsInGame = LevelService.Instance.GetAllBalls();
            for (int i = 0; i < BallsInGame.Length; i++)
            {
                BallsInGame[i].SetNewSpeed(speedMultiplier);
            }
        }

        public void ChangeHP(bool IsDesreasedHp)
        {
            if (IsDesreasedHp)
            {
                DecrementHP();
            }
            else
            {
                Health++;
                OnCatchHpPickUp?.Invoke();
            }
        }

        public void ChangePlatformSize(float scaleToChange)
        {
            Platform PlatformInGame = FindObjectOfType<Platform>();
            PlatformInGame.transform.localScale += new Vector3(scaleToChange, 0);
        }

        public void ChangeScore(int value)
        {
            Score = Mathf.Max(0, Score + value);
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

        public void DoublingBalls()
        {
            Ball BallIngame = FindGameBall();
            Ball newBall = Instantiate(_prefabBall, BallIngame.transform.position, Quaternion.identity);
            newBall.transform.localScale = BallIngame.transform.localScale;
            newBall.StartBall();
        }

        public void ResetBall()
        {
            FindObjectOfType<Ball>().ResetBall();
        }

        public void SetStartParameters()
        {
            SetInitHealth();
            Score = 0;
        }

        #endregion

        #region Private methods

        private Ball FindGameBall()
        {
            Ball BallInGame = FindObjectOfType<Ball>();
            return BallInGame;
        }

        private void LoadNextLevel()
        {
            SceneLoader.Instance.LoadNextGameScene();
        }

        private void OnAllBlocksDestroyed()
        {
            LoadNextLevel();
        }

        private void SetInitHealth()
        {
            Health = _startHP;
            Debug.Log($"GameService startHP{Health}");
            OnHPChanged?.Invoke(Health);
        }

        #endregion
    }
}