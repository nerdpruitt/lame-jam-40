using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlanet : MonoBehaviour
{
    public float speed;
    int rotation;

    void Update()
    {
        if(Input.GetAxisRaw("Horizontal") == 1){
            rotation = -1;
        }
        else if(Input.GetAxisRaw("Horizontal") == -1){
            rotation = 1;
        }
        else{
            rotation = 0;
        }
    }
    void FixedUpdate() {
        transform.Rotate(0, 0, speed * Time.deltaTime * rotation);
    }
}
