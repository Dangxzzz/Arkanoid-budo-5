using UnityEngine;

namespace Arkanoid
{
    public class BottomWall : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerExit2D(Collider2D other)
        {
            GameService.Instance.RemoveHealth();
        }

        #endregion
    }
}