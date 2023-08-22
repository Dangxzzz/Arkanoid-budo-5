using UnityEngine;

namespace Arkanoid.Services
{
    public class SoundService : SingletonMonoBehaviour<SoundService>
    {
        #region Variables

        [SerializeField] private AudioClip _blockDestroy;
        [SerializeField] private AudioClip _pickUpCatch;
        [SerializeField] private AudioClip _loseGame;
        [SerializeField] private AudioClip _onCollision;
        [SerializeField] private AudioClip _explodeSound;

        [SerializeField] private AudioSource _audioSource;

        #endregion

        #region Properties

        public float SoundVolume
        {
            set => _audioSource.volume = value;
        }

        #endregion

        #region Public methods

        public void PlayCollisionSound()
        {
            _audioSource.PlayOneShot(_onCollision);
        }

        public void PlayDestroyBlockSound()
        {
            _audioSource.PlayOneShot(_blockDestroy);
        }

        public void PlayExploseSound()
        {
            _audioSource.PlayOneShot(_explodeSound);
        }

        public void PlayLoseSound()
        {
            _audioSource.PlayOneShot(_loseGame);
        }

        public void PlayPickUpSound()
        {
            _audioSource.PlayOneShot(_pickUpCatch);
        }

        #endregion

        #region Protected methods

        protected override void OnAwake()
        {
            base.OnAwake();
            _audioSource = GetComponent<AudioSource>();
        }

        #endregion
    }
}