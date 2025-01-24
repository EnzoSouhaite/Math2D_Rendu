using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bullet : MonoBehaviour
{
    private Vector2 velocity;
    private float radius = 0.5f;

    public void Initialize(Vector2 direction, float speed)
    {
        velocity = direction.normalized * speed;
    }

    public void Update()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;

        if (Target.Instance != null)
        {
            float combineRadius = radius + Target.Instance.radius;
            float distance = Vector2.Distance(transform.position, Target.Instance.transform.position);

            if (distance <= combineRadius)
            {
                Destroy(gameObject);
                print("L'ennemi à été Toucher");
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 0.5f);
    }
}