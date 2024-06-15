using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public int damage;
    public void OnTriggerEnter2D(Collider2D other) {
        if(other.transform.tag == "Player"){
            other.transform.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
