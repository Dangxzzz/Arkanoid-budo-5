using UnityEngine;

namespace Arkanoid
{
    [RequireComponent(typeof(Collider2D))]
    public class BottomWall : MonoBehaviour
    {
        #region Unity lifecycle

        private void Awake()
        {
            GetComponent<Collider2D>().isTrigger = true;
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(Tags.Ball))
            {
                GameService.Instance.DecrementHP();
                GameService.Instance.ResetBall();
            }
            else
            {
                Destroy(other.gameObject);
            }
        }

        #endregion
    }
}