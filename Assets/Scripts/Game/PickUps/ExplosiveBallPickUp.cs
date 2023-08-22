using System.Collections.Generic;
using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game.PickUps
{
    public class ExplosiveBallPickUp : PickUp
    {
        #region Variables

        [SerializeField] private Sprite _explosiveBallSprite;
        [SerializeField] private Color _explosiveBallTrailColor;
        [SerializeField] private float _explosiveRadius;
        [SerializeField] private LayerMask _blockMask;
        private List<Ball> _allBalls = new();

        #endregion

        #region Unity lifecycle

        private void Awake()
        {
            _allBalls = LevelService.Instance.Balls;
        }

        #endregion

        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();
            for (int i = 0; i < _allBalls.Count; i++)
            {
                _allBalls[i].EnableExplosiveMode(_explosiveRadius, _blockMask, _explosiveBallSprite,
                    _explosiveBallTrailColor);
            }
        }

        #endregion
    }
}