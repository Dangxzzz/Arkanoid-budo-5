using Arkanoid.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.Sounds
{
    public class SoundController : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField] private AudioSource _audioSource;
        [SerializeField] private Slider _sliderSoundVolume;
        [Header("Tags")]
        [SerializeField] private string _sliderTag;
        private string _saveVolume;

        private float _volume;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            if (PlayerPrefs.HasKey(_saveVolume))
            {
                _volume = PlayerPrefs.GetFloat(_saveVolume);
                _audioSource.volume = _volume;
            }

            GameObject sliderObj = GameObject.FindWithTag(_sliderTag);
            if (sliderObj != null)
            {
                _sliderSoundVolume = sliderObj.GetComponent<Slider>();
                _sliderSoundVolume.value = _volume;
            }
            else
            {
                _volume = 0.5f;
                PlayerPrefs.SetFloat(_saveVolume, _volume);
                _audioSource.volume = _volume;
            }

            SoundService.Instance.SoundVolume = _volume;
        }

        private void LateUpdate()
        {
            GameObject sliderObj = GameObject.FindWithTag(_sliderTag);
            if (sliderObj != null)
            {
                _sliderSoundVolume = sliderObj.GetComponent<Slider>();
                _volume = _sliderSoundVolume.value;
                if (_audioSource.volume != _volume)
                {
                    PlayerPrefs.SetFloat(_saveVolume, _volume);
                }
            }

            SoundService.Instance.SoundVolume = _volume;
            _audioSource.volume = _volume;
        }

        #endregion
    }
}