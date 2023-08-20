using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ChangePlatformSizePickUp : PickUp
    {
        #region Variables

        [SerializeField] private float _sizeMultiplier;

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            
            Platform platformInGame = FindObjectOfType<Platform>();
            platformInGame.ChangePlatformSize(_sizeMultiplier);
        }

        #endregion
    }
}