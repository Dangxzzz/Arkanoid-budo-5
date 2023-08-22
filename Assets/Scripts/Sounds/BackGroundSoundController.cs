using UnityEngine;

namespace Arkanoid.Sounds
{
    public class BackGroundSoundController : MonoBehaviour
    {
        #region Variables

        [Header("Tags")]
        [SerializeField] private string _createTag;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            GameObject obj = GameObject.FindWithTag(_createTag);
            if (obj != null)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.tag = _createTag;
                DontDestroyOnLoad(gameObject);
            }
        }

        #endregion
    }
}