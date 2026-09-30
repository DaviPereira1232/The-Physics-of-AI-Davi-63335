using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateMove : MonoBehaviour
{
    public float speed = 0.05f;

    void Update()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }
}
