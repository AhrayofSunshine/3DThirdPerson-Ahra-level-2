using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] private GameObject enemyCollider;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        enemy.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "destroy enemy")
        {
            if (other.tag == "Player")
            {
                enemy.SetActive(true);
            }
        }

    }
}
