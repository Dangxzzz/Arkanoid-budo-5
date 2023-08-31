using UnityEngine;
using UnityEngine.Serialization;

namespace Arkanoid.Services
{
    public class SoundService : SingletonMonoBehaviour<SoundService>
    {
        #region Variables

        private const string VolumePrefskey = "Sound/Volume";
        
        [FormerlySerializedAs("_BSound")]
        [Header("Clips")]
        [SerializeField] private AudioClip _blockDestroySound;
        [SerializeField] private AudioClip _pickUpCatch;
        [SerializeField] private AudioClip _loseGame;
        [SerializeField] private AudioClip _onCollision;
        [SerializeField] private AudioClip _explosionSound;
        
        [Header("AudioSourse")]
        [SerializeField] private AudioSource _audioSource;

        #endregion

        #region Properties

        public float SoundVolume
        {
            get => _audioSource.volume;
            set
            {
                _audioSource.volume = value;
                PlayerPrefs.SetFloat(VolumePrefskey, value);
            }
        }

        #endregion

        #region Public methods

        public void PlayCollisionSound()
        {
            PlaySfx(_onCollision);
        }

        public void PlayBlockDestroySound()
        {
            PlaySfx(_blockDestroySound);
        }

        public void PlayLoseSound()
        {
            PlaySfx(_loseGame);
        }

        public void PlayExplosionSound()
        {
            PlaySfx(_explosionSound);
        }

        public void PlayPickUpSound()
        {
            PlaySfx(_pickUpCatch);
        }

        #endregion

        #region Protected methods

        protected override void OnAwake()
        {
            base.OnAwake();
            _audioSource = GetComponent<AudioSource>();

            if (PlayerPrefs.HasKey(VolumePrefskey))
            {
                SoundVolume = PlayerPrefs.GetFloat(VolumePrefskey);
            }
        }

        #endregion

        #region Private methods

        private void PlaySfx(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }

        #endregion
    }
}