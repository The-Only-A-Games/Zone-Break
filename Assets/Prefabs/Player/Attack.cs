using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;

    public Transform muzzelTransform;
    public PlayerInputActions controls;

    public GameObject anomolyZone;
    public Transform anomolyTransform;
    public Movement movement;


    public float fireRate = 0.25f;
    private float lastTimeShot = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = GetComponent<PlayerInputActions>();
        movement = GetComponent<Movement>();
    }

    // Update is called once per frame
    void Update()
    {
        // Spawning bullet / projectile
        if (Time.time - lastTimeShot >= fireRate)
        {
            if (controls.Shoot)
            {
                if (muzzelTransform != null)
                {
                    // Return a raycast hit.point for the direction the player is
                    // I want to use this movement.MousePosDir to make the bullet travell in the direction of the curso
                    Vector3 dir = movement.MousePosDir; // hit.point
                    dir.y = 0;
                    GameObject b = Instantiate(bullet, muzzelTransform.position, Quaternion.identity);
                    b.transform.forward = dir;
                    b.GetComponent<MoveProjectile>().Fire(dir);


                    lastTimeShot = Time.time;
                }
            }
        }


        // Spawning anomoly zone
        if (Time.time - lastTimeShot >= fireRate)
        {
            if (controls.PowerUp)
            {
                if (muzzelTransform != null)
                {
                    Instantiate(anomolyZone, anomolyTransform.position, anomolyTransform.rotation);
                    lastTimeShot = Time.time;
                }
            }
        }


    }
}
