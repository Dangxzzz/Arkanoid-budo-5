using UnityEngine;
using UnityEngine.SceneManagement;

namespace Arkanoid
{
    public class DownCollider : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerExit2D(Collider2D other)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}