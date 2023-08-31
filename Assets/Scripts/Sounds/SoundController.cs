using Arkanoid.Services;
using UnityEngine;
using UnityEngine.UI;

namespace Arkanoid.Sounds
{
    public class SoundController : MonoBehaviour
    {
        #region Variables

        [Header("Components")]
        [SerializeField]
        private Slider _sliderSoundVolume;

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _sliderSoundVolume.value = SoundService.Instance.SoundVolume;
            _sliderSoundVolume.onValueChanged.AddListener(OnValueChanged);
        }

        private void OnDestroy()
        {
            _sliderSoundVolume.onValueChanged.RemoveListener(OnValueChanged);
        }

        #endregion

        #region Private methods

        private void OnValueChanged(float value)
        {
            SoundService.Instance.SoundVolume = value;
        }

        #endregion
    }
}