using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Canvas explanationCanvas;
    public GameObject player; // 플레이어 오브젝트

    void Start()
    {
        explanationCanvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            explanationCanvas.gameObject.SetActive(true); // 설명 Canvas 활성화
        }
    }
}
