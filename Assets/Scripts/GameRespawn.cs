using UnityEngine;

public class GameRespawn : MonoBehaviour
{
    public Transform respawnPoint; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("collider")) 
        {
            
            transform.position = respawnPoint.position;

            
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
            }
        }
    }
}
