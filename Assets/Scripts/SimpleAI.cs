using UnityEngine;

public class SimpleAI : MonoBehaviour
{
    public float speed = 3.0f;
    public float changeDirectionTime = 3.0f;

    private Vector3 moveDirection;
    private float timer;

    void Start()
    {
        moveDirection = GetRandomDirection();
        timer = changeDirectionTime;
    }

    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            moveDirection = GetRandomDirection();
            timer = changeDirectionTime;
        }

        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    Vector3 GetRandomDirection()
    {
        float angle = Random.Range(0f, 360f);
        return new Vector3(Mathf.Sin(angle), 0, Mathf.Cos(angle));
    }
}
