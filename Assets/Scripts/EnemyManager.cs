using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject TurtlePrefab;
    public Transform[] StartPoints;
    public Transform[] EndPoints;

    void Start()
    {
        SpawnEnemies();
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < StartPoints.Length; i++)
        {
            GameObject turtle = Instantiate(TurtlePrefab);
            EnemyMovement movement = turtle.GetComponent<EnemyMovement>();
            if (movement != null)
            {
                movement.Setup(StartPoints[i], EndPoints[i]);
            }
        }
    }
}
