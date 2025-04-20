using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public float Speed = 3.0f;
    private bool movingToEnd = true;

    void Update()
    {
        if (StartPoint == null || EndPoint == null) return;

        if (movingToEnd)
        {
            transform.position = Vector3.MoveTowards(transform.position, EndPoint.position, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, EndPoint.position) < 0.1f)
            {
                movingToEnd = false;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, StartPoint.position, Speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, StartPoint.position) < 0.1f)
            {
                movingToEnd = true;
            }
        }
    }

    public void Setup(Transform start, Transform end)
    {
        StartPoint = start;
        EndPoint = end;
        transform.position = start.position;
    }
}
