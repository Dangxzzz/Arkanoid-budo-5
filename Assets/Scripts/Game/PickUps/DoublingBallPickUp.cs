namespace Arkanoid
{
    public class DoublingBallPickUp : PickUp
    {
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.DoublingBalls();
        }

        #endregion
    }
}