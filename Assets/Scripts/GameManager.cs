using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject coinTipBoard;
    [SerializeField] private GameObject enemyTipBoard;
    [SerializeField] private GameObject movingPlatformTipBoard;
    [SerializeField] private GameObject startBanner;
    [SerializeField] private GameObject coinsCollectedText;
    [SerializeField] private GameObject healthLabel;
    [SerializeField] private GameObject healthBarImage;
    public GameObject player;
    public Transform spawnPoint1;
    public Transform spawnPoint2;
    //pinne chyaa
    //[SerializeField] private Transform spawnPoint3;

    private Transform currentSpawnPoint;
    public static GameManager instance;
    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    void Start() {
        currentSpawnPoint = spawnPoint1;
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
    }
    //4. show platform tip board
    public void ShowMovingPlatformTip()
    {
        if (movingPlatformTipBoard != null)
            movingPlatformTipBoard.SetActive(true);
    }

    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        currentSpawnPoint = newSpawnPoint;
    }

    public void RespawnPlayer(GameObject player) {
        player.transform.position = currentSpawnPoint.position;
        player.SetActive(true);
    }

}
