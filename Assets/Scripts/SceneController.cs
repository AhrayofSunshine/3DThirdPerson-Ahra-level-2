using UnityEngine;

public class SceneController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("StartBanner"))
        {
            other.gameObject.SetActive(false);
        }
    }
}
