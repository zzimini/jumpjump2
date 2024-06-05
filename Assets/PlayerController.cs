using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera thirdPersonCamera;
    public Camera firstPersonCamera;
    public GameObject tutorialCanvas;

    void Start()
    {
        firstPersonCamera.enabled = false;
        thirdPersonCamera.enabled = true;
        tutorialCanvas.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TutorialCube"))
        {
            tutorialCanvas.SetActive(true);
            Time.timeScale = 0; // ���� �Ͻ�����
        }
    }

    public void StartGame()
    {
        tutorialCanvas.SetActive(false);
        thirdPersonCamera.enabled = false;
        firstPersonCamera.enabled = true;
        Time.timeScale = 1; // ���� �簳
    }
}
