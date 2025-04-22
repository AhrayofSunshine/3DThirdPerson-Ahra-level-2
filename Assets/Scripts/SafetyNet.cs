using UnityEngine;

public class SafetyNet : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPt;

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) 
        {
            player.transform.position = respawnPt.transform.position;
        }
    }
}
