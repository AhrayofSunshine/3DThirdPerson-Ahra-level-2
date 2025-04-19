using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class HealthBarManager : MonoBehaviour
{
    //[SerializeField] private TextMeshProUGUI healthLabel;
    [SerializeField] private Image healthBar;
    [SerializeField] private GameObject player;
    [SerializeField] private PlayerMovement playerMovement;
    float healthPercentage;
    [SerializeField] private TextMeshProUGUI coinsCollectedText;
    public UIManager uiManager;
    public int CurrentHealth { get; private set; }
    //health
    public int maxHealth = 3;
    private int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void DamagePlayer()
    {
        currentHealth--;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        UpdateHealthBar();

        if (currentHealth <= 0)
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        if (playerMovement != null)
        {
            playerMovement.RespawnPlayer();
            ResetPlayer();
        }
    }
    void ResetPlayer()
    {
        GameManager.instance.SetSpawnPoint(GameManager.instance.spawnPoint1);
        GameManager.instance.RespawnPlayer(player);
        player.SetActive(true);

        currentHealth = maxHealth;
        UpdateHealthBar();
        UIManager.instance.ResetCoins();
    }

    void ResetHealth()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }
    void UpdateHealthBar() {
        healthPercentage = (float)currentHealth / (float)maxHealth;
        healthBar.fillAmount = healthPercentage;

        switch (currentHealth) {
            case 3:
                healthBar.color = Color.green;
                break;
            case 2:
                healthBar.color = Color.yellow;
                break;
            case 1:
                healthBar.color = Color.red;
                break;
        }
    }
}
