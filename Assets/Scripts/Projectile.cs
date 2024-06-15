using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, waitTime, lifeTime;
    public bool isCharge;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        lifeTime -= Time.deltaTime;
        if(waitTime > 0)
        {
            waitTime -= Time.deltaTime;
        }
        else
        {
            transform.Translate(0f, speed, 0f);
        }
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy" && isCharge == false)
        {
            collision.GetComponent<EnemyHealth>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
