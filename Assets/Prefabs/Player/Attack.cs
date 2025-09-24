using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;

    public Transform muzzelTransform;
    public PlayerInputActions controls;

    public GameObject anomolyZone;
    public Transform anomolyTransform;


    public float fireRate = 0.25f;
    private float lastTimeShot = 0.0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        controls = GetComponent<PlayerInputActions>();
        // muzzelTransform = FindAnyObjectByType<Muzzel>()
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
                    Instantiate(bullet, muzzelTransform.position, muzzelTransform.rotation);
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
