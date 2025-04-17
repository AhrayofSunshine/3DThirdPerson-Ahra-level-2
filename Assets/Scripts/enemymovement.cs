using UnityEngine;

public class enemymovement : MonoBehaviour
{
    float enemySpeed = 5.0f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyMovement = new Vector3(1,0,0) * enemySpeed * Time.deltaTime;
        transform.Translate(enemyMovement);
    }
    

}
