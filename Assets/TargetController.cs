using UnityEngine;

public class TargetController : MonoBehaviour
{
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Arrow")
        {
            ArrowScoreManager.instance.AddScore(10);
            Destroy(gameObject);
        }
    }
}
