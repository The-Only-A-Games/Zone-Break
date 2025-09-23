using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject bullet;
    public Transform muzzelTransform;
    public PlayerInputActions controls;


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
    }
}
