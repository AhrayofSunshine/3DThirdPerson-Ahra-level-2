using UnityEngine;
using System.Collections.Generic;
public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject coinTipBoard;
    [SerializeField] private GameObject enemyTipBoard;
    [SerializeField] private GameObject movingPlatformTipBoard;
    [SerializeField] private GameObject startBanner;
    [SerializeField] private GameObject coinsCollectedText;
    [SerializeField] private GameObject healthLabel;
    [SerializeField] private GameObject healthBarImage;
    [SerializeField] private GameObject finalHealth;
    [SerializeField] private GameObject RKTrigger;
    [SerializeField] private GameObject successTrigger;



    public GameObject player;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    //pinne chyaa
    //[SerializeField] private Transform spawnPoint3;
    private List<GameObject> coins = new List<GameObject>();
  
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start() {
 
        if (coinsCollectedText != null)
        {
            coinsCollectedText.SetActive(false);
        }
        if (healthLabel != null)
        {
            healthLabel.SetActive(false);
        }

        healthBarImage.SetActive(false);

    }

    //1. hide banner
    public void HideBanner() {
        if (startBanner != null)
        {
            startBanner.SetActive(false);
        }
    }
    //2. show coin tip board
    public void ShowCoinTip() { 
        if(coinTipBoard != null)
            coinTipBoard.SetActive(true);
        //show these when the player collides witg the tipboard
        if (coinsCollectedText != null)
            coinsCollectedText.SetActive(true);
        if (healthLabel != null)
            healthLabel.SetActive(true);
        healthBarImage.SetActive(true);
    }
    //3. show enemy tip board
    public void ShowEnemyTip()
    {
        if (enemyTipBoard != null)
            enemyTipBoard.SetActive(true);
        if (healthLabel != null)
            healthLabel.SetActive(true);
        healthBarImage.SetActive(true);
    }
    //4. show platform tip board
    public void ShowMovingPlatformTip()
    {
        if (movingPlatformTipBoard != null)
            movingPlatformTipBoard.SetActive(true);
        healthLabel.SetActive(false);
        healthBarImage.SetActive(false);
    }


    public void RegisterCoin(GameObject coin) {
        if (!coins.Contains(coin)) { 
            coins.Add(coin);
        }
    }
    public void ResetCoins() {
        foreach (GameObject coin in coins) {
            if (coin != null) {
                coin.SetActive(true);
            }
        }
    }
    public void showFinalHealth()
    {
        if (finalHealth != null)
        {
            finalHealth.SetActive(true);
        }
        //healthLabel.SetActive(true);
        //healthBarImage.SetActive(true);
    }
    public void showFinalTrigger()
    {
        if (RKTrigger != null)
        {
            RKTrigger.SetActive(true);
        }
        healthLabel.SetActive(false);
        healthBarImage.SetActive(false);
    }
    public void showSuccessTrigger()
    {
        if (successTrigger != null)
        {
            successTrigger.SetActive(true);
        }
        
    }

}
