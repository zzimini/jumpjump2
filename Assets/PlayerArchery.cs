using UnityEngine;

public class PlayerArchery : MonoBehaviour
{
    public Camera playerCamera;
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public Transform target;

    public float arrowSpeed = 25f;

    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // ��Ŭ��
        {
            AimAtTarget();
        }

        if (Input.GetMouseButtonDown(0)) // ��Ŭ��
        {
            ShootArrow();
        }
    }

    void AimAtTarget()
    {
        Vector3 direction = (target.position - playerCamera.transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        playerCamera.transform.rotation = Quaternion.Slerp(playerCamera.transform.rotation, lookRotation, Time.deltaTime * 10f);
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, arrowSpawnPoint.rotation);
        Rigidbody rb = arrow.GetComponent<Rigidbody>();
        rb.velocity = arrowSpawnPoint.forward * arrowSpeed;
    }
}
