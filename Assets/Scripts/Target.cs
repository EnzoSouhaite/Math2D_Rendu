using UnityEngine;

public class Target : MonoBehaviour
{

    public Transform A;
    public Transform B;
    public float speed = 2.0f;

    private Vector2 startPostion;
    private Vector2 endPostion;
    private float journeyLength;

    public float radius = 1.0f;

    private static Target instance;

    public static Target Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<Target>();
            }
            return instance;
        }
    }

    private void Start()
    {
        startPostion = A.position;
        endPostion = B.position;

        journeyLength = Vector2.Distance(startPostion, endPostion);
    }

    public void Update()
    {
        float time = Time.time * speed;

        float t = Mathf.PingPong(time, journeyLength) / journeyLength;

        transform.position = Vector2.Lerp(startPostion, endPostion, t);
    }
    private void Awake()
    {
        instance = this;
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
