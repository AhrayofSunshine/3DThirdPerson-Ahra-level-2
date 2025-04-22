using UnityEngine;
using UnityEngine.SceneManagement;
public class SucessManager : MonoBehaviour
{
    [SerializeField] GameObject successpopup;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (successpopup != null) {
                successpopup.SetActive(true);
            }
        }
    }

    public void RestartGame() {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame() { 
    
        Application.Quit();
    
    }
}
