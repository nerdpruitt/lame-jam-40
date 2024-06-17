using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillAfterTime : MonoBehaviour
{
    public float Timer;
    public void Start(){
        Invoke("Kill", Timer);
    }
    public void Kill(){
        Destroy(this.gameObject);
    }
}
