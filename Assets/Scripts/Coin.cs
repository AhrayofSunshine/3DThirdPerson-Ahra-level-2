using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class Coin : MonoBehaviour
{
    public AudioSource coinSound;
    float coinSpeed = 180f;
    private int coinValue = 1;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameManager.instance.RegisterCoin(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 movement = new Vector3(0,0,1) * coinSpeed * Time.deltaTime;
        transform.Rotate(movement);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Messenger<int>.Broadcast(GameEvent.COIN_COLLECTED, coinValue);
            coinSound.Play();
            this.gameObject.SetActive(false);
            
        }
    }
}
