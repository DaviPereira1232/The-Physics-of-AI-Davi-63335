using Unity.VisualScripting;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject firingTransform;
    public GameObject eriu;
    public GameObject BulletShell;
    public float speed = 15;
    public float rotSpeed = 2;
    public GameObject mal;
    void Update()
    {
        Vector3 direction = (mal.transform.position - this.transform.position).normalized;
        Quaternion lookroot = Quaternion.LookRotation( new Vector3(direction.x, 0, direction.z) );
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, lookroot, Time.deltaTime * rotSpeed);
        rottut();       
        if (Input.GetKeyDown(KeyCode.Space))
        {
                Launch(firingTransform.transform.position, this.transform.rotation);        
        }
    }

    float? Dondevem(bool low)
    {
        Vector3 targetD = mal.transform.position - this.transform.position;
        float y = targetD.y;
        targetD.y = 0;
        float x =  targetD.magnitude;
        float gravity = 9.8f;
        float sSqr = speed * speed;
        float raiz = (speed * speed) - gravity * (gravity * x * x + 2 * y * sSqr);

        if (raiz >= 0)
        {
            float root = Mathf.Sqrt(raiz);
            float alto = sSqr + root;
            float baixo = sSqr + root;

            if (low)
                return (Mathf.Atan2(baixo, gravity * x) * Mathf.Rad2Deg);
            else return (Mathf.Atan2(alto, gravity * x) * Mathf.Rad2Deg);
        }
        else
            return null;
    }

/*    Vector3 Dondevem()
    {
        Vector3 dist = mal.transform.position - this.transform.position;
        Vector3 frente = mal.transform.forward * mal.GetComponent<Drive>().speed;
        float velo = BulletShell.GetComponent<Bullet>().speed;
        
        float a = Vector3.Dot(frente, frente) - velo * velo;
        float b = Vector3.Dot(dist, frente);
        float c = Vector3.Dot(dist, dist);

        float d = b * b - a * c;
        if (d < 0.1f) return Vector3.zero;

        float sqrt = Mathf.Sqrt(d);
        float t1 = (-b - sqrt) / c;
        float t2 = (-b + sqrt) / c;

        float t = 0;

        if (t1 < 0 && t2 < 0) t = 0;
        else if(t1 < 0) t = t2;
        else if(t2 < 0) t = t1;
        else
        {
            t = Mathf.Max(new float[] { t1, t2 });
        }
        return t * dist + frente;
    } 
*/

void Launch(Vector3 t, Quaternion r)
    {
        GameObject aaaaa = Instantiate(BulletShell, t, r);
        aaaaa.GetComponent<Rigidbody>().linearVelocity = speed * eriu.transform.forward;
    }

    void rottut()
    {
        float? angle = Dondevem(true);
        if (angle != null)
        {
            eriu.transform.localEulerAngles = new Vector3(360 - (float)angle, 0f, 0f);
        }
    }
}

