using Arkanoid.Services;
using UnityEngine;

namespace Arkanoid.Game
{
    public class ExplosiveBlock : Block
    {
        #region Variables

        [Header(nameof(ExplosiveBlock))]
        [SerializeField] private float _explosiveRadius = 1f;
        [SerializeField] private LayerMask _blockMask;

        #endregion

        #region Protected methods

        protected override void OnDestroyedActions()
        {
            base.OnDestroyedActions();
            SoundService.Instance.PlayExploseSound();
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, _explosiveRadius, _blockMask);

            foreach (Collider2D col in colliders)
            {
                if (col.TryGetComponent(out Block block))
                {
                    block.ForceDestroy();
                }
            }
        }

        #endregion
    }
}