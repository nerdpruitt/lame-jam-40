using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth, health;
    //public float invincibleTime;
   // float timer;
    //bool isInvincible;
    //public bool invicibleTimeAllowed, usesHealthbar;
    //public Slider healthbar;

    public void Start()
    {
        health = maxHealth;
    }

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
                Destroy(this.gameObject);
            }
        //}
    }

    //public void Update(){
     //   if (timer > 0)
      //  {
     //       timer -= Time.deltaTime;
     //   }
      //  else if (isInvincible == true)
     //   {
      //      isInvincible = false;
      //  }
    //}
   // public void HealthUpdate()
   // {
   //     healthbar.value = health;
   // }
}
