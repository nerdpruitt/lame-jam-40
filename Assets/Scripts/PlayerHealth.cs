using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour
{
    public int health, maxHealth, invinceTime, scrap;
    public Color invincColor;
    public Slider healthBar;
    public Text scrapText;
    public AudioSource hitsound;
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
            SceneManager.LoadScene("MainMenu");
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
        this.gameObject.GetComponent<Collider2D>().enabled = false;
        this.gameObject.GetComponent<SpriteRenderer>().color = invincColor;
        Invoke("Reenable", invinceTime);
        hitsound.Play();
    }
    public void Reenable(){
        this.gameObject.GetComponent<Collider2D>().enabled = true;
        this.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }
    public void AddMoney(int amount){
        scrap += amount;
        scrapText.text = "Scrap: " + scrap.ToString();
    }
    public void LoseMoney(int amount){
        scrap -= amount;
        scrapText.text = "Scrap: " + scrap.ToString();
    }
}
