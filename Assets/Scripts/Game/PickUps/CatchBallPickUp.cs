namespace Arkanoid
{
    public class CatchBallPickUp: PickUp
    {
        #region Protected methods

        protected override void PerformActions()
        {
            base.PerformActions();

            GameService.Instance.ResetBall();
        }

        #endregion
    }
}