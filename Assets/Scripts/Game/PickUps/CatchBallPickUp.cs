using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class CatchBallPickUp : PickUp
    {
        #region Variables

        [Header("Configs")]
        [SerializeField] private Sprite _gluePlatformSprite;
        [SerializeField] private float duration;
        [SerializeField] private Color _gluePlatformColor;

        private Platform _platform;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            _platform = FindObjectOfType<Platform>();
            _platform.EnableGlueMode(duration, _gluePlatformSprite,_gluePlatformColor);
            Debug.Log("Cathced");
        }

        #endregion
    }
}