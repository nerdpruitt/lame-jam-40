using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbit : MonoBehaviour
{
    public float speed;
    public int direction;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(0, 0, speed * Time.deltaTime * direction);
    }
}
