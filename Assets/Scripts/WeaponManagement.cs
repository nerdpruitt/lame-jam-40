using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;

public class WeaponManagement : MonoBehaviour
{
    public GameObject[] weapons, currentWeapons;
    public Transform[] weaponslots;
    public PlayerHealth playerWallet;
    public bool[] slotTaken;
    public int weaponType, activeWeapon;
    public float timeBetweenShots;
    float waitTime;
    
    public void Start(){
        playerWallet = this.GetComponent<PlayerHealth>();
        //SetWeapon(0);
        //AddWeapon(0);
    }
    public void Update(){
        if(Input.GetButtonDown("Fire1") && waitTime <= 0){
            int i = 0;
            foreach(GameObject obj in currentWeapons){
                if(obj == null){
                    i++;
                }
            }
            if(i != currentWeapons.Length){               
                Debug.Log("The array isn't null.");
                CheckWeapon();
                currentWeapons[activeWeapon].GetComponent<Weapon>().Fire();
                waitTime = timeBetweenShots;
                activeWeapon++;
                if(activeWeapon == currentWeapons.Length){
                activeWeapon = 0;
                }
            }           
        }
    }

    public void FixedUpdate(){
        waitTime -= Time.deltaTime;
    }
    
    public void SetWeapon(int weapon){
        weaponType = weapon;
    }
    public void AddWeapon(int slot){
        int cost = 0;
        Debug.Log("Started");
        if(weaponType == 0){
            cost = 100;
        }
        else if(weaponType == 1){
            cost = 150;
        }
        else if(weaponType == 2){
            cost = 200;
        }
        else if(weaponType == 3){
            cost = 300;
        }
        Debug.Log("Instantiating.");
        if(playerWallet.scrap >= cost){
            if(slotTaken[slot] != true){
                playerWallet.LoseMoney(cost);
                Debug.Log("It should be there");
                currentWeapons[slot] = Instantiate(weapons[weaponType], weaponslots[slot]);
                slotTaken[slot] = true;
                Debug.Log("Is it not?");
            }    
        }   
    }
    public void RemoveWeapon(int slot){
        if(slotTaken[slot] == true){
            Destroy(currentWeapons[slot]);
            slotTaken[slot] = false;
        }
    }
    private void CheckWeapon(){
        if(currentWeapons[activeWeapon] == null){
            activeWeapon++;
            if(activeWeapon == currentWeapons.Length){
            activeWeapon = 0;
            }
            CheckWeapon();
        }
    }
}
