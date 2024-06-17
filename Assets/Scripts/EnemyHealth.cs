using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth, health, scrapAmount;
    public PlayerHealth player;
    public AudioSource death;
    //public float invincibleTime;
   // float timer;
    //bool isInvincible;
    //public bool invicibleTimeAllowed, usesHealthbar;
    //public Slider healthbar;

    public void Start()
    {
        health = maxHealth;
        Debug.Log("Finding Player");
        player = GameObject.FindObjectOfType<PlayerHealth>();
        Debug.Log("Finished.");
    }

    //public void FixedUpdate(){
    //    if(player == null){
    //        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    //    }
    //}

    public void TakeDamage(int damage)
    {
        //if (timer <= 0)
        //{
            health -= damage;
            //if (invicibleTimeAllowed)
            //{
                //isInvincible = true;
                //timer = invincibleTime;
            //}
            //if (usesHealthbar)
           // {
               // HealthUpdate();
           // }
            if(health <= 0)
            {
                player.AddMoney(scrapAmount);
                death.Play();
                Destroy(this.gameObject);
            }
        //}
    }

}
