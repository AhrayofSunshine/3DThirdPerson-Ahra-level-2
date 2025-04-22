using UnityEngine;

public class SafetyNet : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform respawnPt;
    [SerializeField] private GameObject respawnDust;
    private Animator playerAnimator;
    private void Start()
    {
        if (player != null) {
            playerAnimator = player.GetComponent<Animator>();
        }
    }

    private void OnTriggerEnter(Collider other) {

        if (other.CompareTag("Player")) 
        {
            player.transform.position = respawnPt.transform.position;

            if (respawnDust != null) {
                GameObject particles = Instantiate(respawnDust, respawnPt.position, Quaternion.identity);
                Destroy(particles, 1f);
            }
            if (playerAnimator != null) {
                playerAnimator.ResetTrigger("Fall");
                playerAnimator.SetBool("ISFalling", false);
            }

        }
    }
}
