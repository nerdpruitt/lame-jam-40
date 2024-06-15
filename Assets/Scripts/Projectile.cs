using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float distance;
    public float Speed;
    public float lifeTime;
    public LayerMask WhatIsSolid;
    public int damage;
    public bool EnemyProjectile;
    public float waitTime;
    //public GameObject destroyEffect;
    private void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }
    public void Update()
    {

        waitTime -= Time.deltaTime;
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, WhatIsSolid);
        if (hitInfo.collider != null)
        {
            
            if (EnemyProjectile == false)
            {
                if (hitInfo.collider.CompareTag("Enemy"))
                {
                    hitInfo.collider.GetComponent<EnemyHealth>().TakeDamage(damage);
                }
            }
            DestroyProjectile();
        }
        if (waitTime <= 0)
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
        
    }
    public void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
