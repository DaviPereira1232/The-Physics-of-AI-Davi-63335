using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LateUpdateMove : MonoBehaviour
{
    public float speed = 0.05f;
    void LateUpdate()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
