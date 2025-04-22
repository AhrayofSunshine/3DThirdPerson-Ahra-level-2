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
                SetGameActive(false);
            }
        }
    }
    public void SetGameActive(bool active)
    {
        if (active)
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;


        }
        else {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;

        }
        
    }
    public void RestartGame() {

        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitGame() { 
    
        Application.Quit();
    
    }
}
