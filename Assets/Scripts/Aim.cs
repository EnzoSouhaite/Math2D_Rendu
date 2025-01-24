using UnityEngine;

public class Aim : MonoBehaviour
{

    public Transform reticule;
    public Bullet bulletPrefab;

    public float angularSpeed = 1.0f;
    public float powerSpeed = 1.0f;

    private float minAngle = 0f;
    private float maxAngle = 180f;
    private float currentAngle = 90f;

    private float minPower = 0f;
    private float maxPower = 10f;
    private float currentPower = 5f;

    public float radius = 5f;

    public void Update()
    {
        float dt = Time.deltaTime;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            currentAngle += angularSpeed * dt;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            currentAngle -= angularSpeed * dt;
        }

        currentAngle = Mathf.Clamp(currentAngle, minAngle, maxAngle);

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            currentPower -= powerSpeed * dt;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            currentPower += powerSpeed * dt;
        }

        currentPower = Mathf.Clamp(currentPower, minPower, maxPower);


        float angleRad = Mathf.Deg2Rad * currentAngle;
        Vector2 reticulePosition = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad)) * (radius + currentPower);
        reticule.position = (Vector2)transform.position + reticulePosition;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet();
        }
    }

    public void Bullet()
    {
        Bullet newBullet = GameObject.Instantiate<Bullet>(bulletPrefab, transform.position, Quaternion.identity);
        float angleRad = Mathf.Deg2Rad * currentAngle;
        Vector2 direction = new Vector2(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
        newBullet.Initialize(direction, currentPower);
    }
}
