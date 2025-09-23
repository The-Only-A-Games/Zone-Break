using UnityEngine;

public class Cystal : MonoBehaviour
{
    public GameObject zone;
    public float health = 10;
    public float hitDamage = 5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (zone != null && health <= 0)
        {
            Destroy(zone);
        }
    }

    public void OnHit()
    {
        health -= hitDamage;
    }
}
