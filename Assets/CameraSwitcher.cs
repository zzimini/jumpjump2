using UnityEngine;

public class CameraSwitcher : MonoBehaviour
{
    public Canvas explanationCanvas;
    public GameObject player; // �÷��̾� ������Ʈ

    void Start()
    {
        explanationCanvas.gameObject.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            explanationCanvas.gameObject.SetActive(true); // ���� Canvas Ȱ��ȭ
        }
    }
}
