using UnityEngine.SceneManagement;

namespace Arkanoid.Services
{
    public class SceneLoader : SingletonMonoBehaviour<SceneLoader>
    {
        #region Public methods

        public void LoadNextGameScene()
        {
            int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
            SceneManager.LoadScene(nextSceneIndex);
        }

        public void ReloadCurrentScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        #endregion
    }
}