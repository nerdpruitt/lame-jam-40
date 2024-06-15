using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int health, maxHealth, invinceTime;
    public Color invincColor;
    public Slider healthBar;
    //public AudioSource hurtSound;
    public void Start(){
        healthBar.maxValue = maxHealth;
        health = maxHealth;
        healthBar.value = health;
    }
    private void Update()
    {
        if (health <= 0)
        {
            //SceneManager.LoadScene("LoseScreen");
            Destroy(this.gameObject);
        }
        if(health > maxHealth){
            health = maxHealth;
        }
    }
    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.value = health;
        //hurtSound.Play();
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = invincColor;
        Invoke("Reenable", invinceTime);
    }
    public void Reenable(){
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
}
