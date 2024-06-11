using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class FireBullet2 : MonoBehaviour
{
    public Transform bulletPos;
    public GameObject bullet;
    public Image image;
    public CinemachineVirtualCamera vc;

    private bool toTarget = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            toTarget = !toTarget;
            image.GetComponent<Image>().enabled = !image.GetComponent<Image>().enabled;
            vc.GetCinemachineComponent<Cinemachine3rdPersonFollow>().CameraDistance = toTarget ? 1.5f : 5f;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (toTarget)
            {
                Vector3 screenCenter = new Vector3(Screen.width / 2, Screen.height / 2, 0);
                Ray ray = Camera.main.ScreenPointToRay(screenCenter);
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.red, 2f); // ���� ���������� �׸���
                Debug.Log("Ray Origin: " + ray.origin + ", Direction: " + ray.direction);

                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.Log("Raycast hit: " + hit.collider.name);
                    GameObject obj = Instantiate(bullet, bulletPos.position, Quaternion.identity);
                    obj.tag = "Arrow"; // �±� ����
                    obj.transform.LookAt(hit.point);
                    obj.GetComponent<Rigidbody>().velocity = obj.transform.forward * 30;
                    Vector3 targetPosition = hit.point;
                    targetPosition.y = transform.position.y;
                    transform.LookAt(targetPosition);
                    Destroy(obj, 2.0f);
                }
                else
                {
                    Debug.Log("Raycast did not hit anything.");
                }
            }
            else
            {
                GameObject obj = Instantiate(bullet, bulletPos.position, bulletPos.rotation);
                obj.tag = "Arrow"; // �±� ����
                obj.GetComponent<Rigidbody>().velocity = bulletPos.transform.forward * 30;
                Destroy(obj, 2.0f);
            }
        }
    }
}
