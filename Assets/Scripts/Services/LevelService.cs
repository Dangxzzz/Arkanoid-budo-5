using System;
using Arkanoid.Game;

namespace Arkanoid.Services
{
    public class LevelService : SingletonMonoBehaviour<LevelService>
    {
        #region Events

        public event Action OnAllBlocksDestroyed;

        #endregion

        #region Unity lifecycle

        private void Update()
        {
            Block[] blocks = GetAllAliveBlocks();
            if (blocks.Length == 0)
            {
                OnAllBlocksDestroyed?.Invoke();
            }
        }

        #endregion

        #region Public methods

        public Ball[] GetAllBalls()
        {
            return FindObjectsOfType<Ball>();
        }

        #endregion

        #region Private methods

        private Block[] GetAllAliveBlocks()
        {
            return FindObjectsOfType<Block>();
        }

        #endregion
    }
}