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
    public bool EnemyProjectile, tracking, doesTrack;
    public float waitTime, rotationModifier;
    public Transform target;
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
        if (tracking == false)
        {
            transform.Translate(Vector2.up * Speed * Time.deltaTime);
        }
        else{
            transform.position = Vector2.MoveTowards(transform.position, target.position, Speed * Time.deltaTime);
            Vector3 vectorToTarget = target.transform.position - transform.position;
            float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg - rotationModifier;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * Speed);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other){
        if (other.tag == "Enemy" && doesTrack){
            target = other.transform;
            tracking = true;
        }
    }
    public void DestroyProjectile()
    {
        //Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
