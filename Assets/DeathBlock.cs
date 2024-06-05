using System.Collections;
using StarterAssets;
using UnityEngine;

public class DeathBlock : MonoBehaviour
{
    public GameObject player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            StartCoroutine(ResetPlayerPosition());
        }
    }

    IEnumerator ResetPlayerPosition()
    {
        // Disable player controls
        var thirdPersonController = player.GetComponent<ThirdPersonController>();
        var characterController = player.GetComponent<CharacterController>();
        var rigidbody = player.GetComponent<Rigidbody>();

        thirdPersonController.enabled = false;
        characterController.enabled = false;

        // Temporarily disable physics interactions
        if (rigidbody != null)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
            rigidbody.isKinematic = true; // Temporarily set to kinematic
        }

        yield return new WaitForSeconds(2);

        // Reset player position
        player.transform.position = CheckPointBlock.ori;
        player.transform.rotation = Quaternion.identity; // Reset rotation if needed

        // Wait briefly to ensure the position is set
        yield return new WaitForSeconds(0.1f);

        // Re-enable player controls and Rigidbody physics
        if (rigidbody != null)
        {
            rigidbody.isKinematic = false; // Re-enable physics interactions
            rigidbody.velocity = Vector3.zero; // Ensure the velocity is reset again
            rigidbody.angularVelocity = Vector3.zero;
        }

        characterController.enabled = true;
        thirdPersonController.enabled = true;
    }
}
