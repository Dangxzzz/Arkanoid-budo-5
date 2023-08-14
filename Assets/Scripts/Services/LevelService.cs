using System;

namespace Arkanoid
{
    public class LevelService : SingletonMonoBehaviour<LevelService>
    {
        #region Events

        public event Action OnAllBlocksDestroyed;

        public event Action<bool> OnAllBallsDestroyed;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Block[] blocks = GetAllAliveBlocks();
            if (blocks.Length == 0)
            {
                OnAllBlocksDestroyed?.Invoke();
            }
            if (IsOneAliveBall())
            {
                OnAllBallsDestroyed?.Invoke(true);
            }
            else
            {
                OnAllBallsDestroyed?.Invoke(false);
            }
        }

        #endregion

        #region Private methods

        private Block[] GetAllAliveBlocks()
        {
            return FindObjectsOfType<Block>();
        }

        public Ball[] GetAllBalls()
        {
            return FindObjectsOfType<Ball>();
        }
        public bool IsOneAliveBall()
        {
            Ball[] balls = GetAllBalls();
           if (balls.Length ==1)
           {
               return true;
           }
           else
           {
               return false;
           }
        }

        #endregion
    }
}