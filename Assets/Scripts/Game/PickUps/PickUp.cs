using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class PickUp : MonoBehaviour
    {
        #region Variables

        [SerializeField] private int _scoreToChange;

        #endregion

        #region Unity lifecycle

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Platform))
            {
                SoundService.Instance.PlayPickUpSound();
                PerformActions();
                Destroy(gameObject);
            }
        }

        #endregion

        #region Protected methods

        protected virtual void PerformActions()
        {
            GameService.Instance.ChangeScore(_scoreToChange);
        }

        #endregion
    }
}