using UnityEngine;

public class SpikyManager : MonoBehaviour
{
    public HealthBarManager health;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player")) {
            health.DamagePlayer();
        }
    }
}
