using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class GameStarter : MonoBehaviour
    {
        #region Unity lifecycle

        private void Start()
        {
            GameService.Instance.StartLevel();
        }

        #endregion
    }
}