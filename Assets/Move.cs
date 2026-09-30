using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject goal;
    Vector3 direction;
    float speed = 5;

    private void Start()
    {
       
    }
    void Update()
    {
        Vector3 TargetPosXZ = new Vector3(goal.transform.position.x,this.transform.position.y,goal.transform.position.z);

        direction = TargetPosXZ - this.transform.position;
        if (Vector3.Angle(direction, this.transform.forward) < 20)
        {
            if (direction.sqrMagnitude < 100)
            {
                this.transform.LookAt(TargetPosXZ);
                if (direction.sqrMagnitude > 4)
                {
                    Vector3 velocity = direction.normalized * speed * Time.deltaTime;
                    this.transform.Translate(velocity);

                }
            }
        }
    }
}
