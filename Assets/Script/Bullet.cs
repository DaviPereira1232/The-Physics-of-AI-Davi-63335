using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 0;
    float Yspeed = 0;
    public GameObject explosion;
    float force = 1;
    float mass = 10;
    float drag = 1;
    float gravity = 9.8f;
    float gAccel;
    float acceleration;
    void Update()
    {
        transform.Translate(transform.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "tank")
        {
            GameObject exp = Instantiate(explosion, this.transform.position, Quaternion.identity);
            Destroy(exp, 0.5f);
            Destroy(gameObject);
        }
    }

    void Start()
    {
        acceleration = force / mass;
        speed += acceleration * 1;
        gAccel = gravity / mass;
    }

    void LateUpdate()
    {
        speed *= (1 - Time.deltaTime * drag);
        Yspeed = gAccel * Time.deltaTime;
        this.transform.Translate(0,Yspeed,speed * Time.deltaTime);
    }
}
