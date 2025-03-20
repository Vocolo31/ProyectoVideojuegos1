using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float speed = 4.5f;
    private Vector2 direction;
    public float lifeTime;

    public void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    public void SetDirection(bool isRight)
    {
        direction = isRight ? Vector2.right : Vector2.left;

        transform.rotation = isRight ? Quaternion.identity : Quaternion.Euler(0, 180, 0);
    }

    private void Update()
    {
        transform.position += (Vector3)direction * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}