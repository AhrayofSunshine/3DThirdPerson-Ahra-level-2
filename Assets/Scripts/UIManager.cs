using UnityEngine;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
public class UIManager : MonoBehaviour
{
    [SerializeField] private SuccessPopup successPopup;
    //[SerializeField] private OptionsPopup OptionsPopup;
    //[SerializeField] private SettingsPopup SettingsPopup;
    //private int Coin = 0;
     public TextMeshProUGUI coin;
    private int coinCollected = 0;
    private int totalCoins = 7;
    public void ShowSuccessPopup()
    {
        successPopup.Open();
    }

   
    private void Awake()
    {
        Messenger<int>.AddListener(GameEvent.COIN_COLLECTED, OnCoinCollected);

    }
    private void OnDestroy()
    {
        Messenger<int>.RemoveListener(GameEvent.COIN_COLLECTED, OnCoinCollected);
    }
    private void Start()
    {
        
    }
    void OnCoinCollected(int value)
    {
        coinCollected++;
        coin.text = "Coin Collected: " + coinCollected;
        if (coinCollected == totalCoins)
        {
            Debug.Log("all Coins cOLLECTED");
            coin.gameObject.SetActive(false);
        }
    }
   
}