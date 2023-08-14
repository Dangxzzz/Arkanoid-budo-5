using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUp : MonoBehaviour
    {
        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                PerformActions();
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            // TODO: Show vfx
            // TODO: PLay sfx
        }

        #endregion
    }
}