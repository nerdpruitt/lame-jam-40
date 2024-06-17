using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

public class WeaponManagement : MonoBehaviour
{
    public GameObject[] weapons, currentWeapons;
    public Image[] activeIcons;
    public Color selectedColor;
    Color nonColor;
    public Image MachineIcon, ShotIcon, LauncherIcon, TeslaIcon;
    public Transform[] weaponslots;
    public PlayerHealth playerWallet;
    public bool[] slotTaken;
    public int weaponType, activeWeapon;
    public float timeBetweenShots;
    float waitTime;
    Image icon;
    
    public void Start(){
        playerWallet = this.GetComponent<PlayerHealth>();
        nonColor = activeIcons[0].color;
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
                //activeIcons[activeWeapon].color = nonColor;
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
            icon = MachineIcon;
        }
        else if(weaponType == 1){
            cost = 150;
            icon = ShotIcon;
        }
        else if(weaponType == 2){
            cost = 200;
            icon = LauncherIcon;
        }
        else if(weaponType == 3){
            cost = 300;
            icon = TeslaIcon;
        }
        Debug.Log("Instantiating.");
        if(playerWallet.scrap >= cost){
            if(slotTaken[slot] != true){
                playerWallet.LoseMoney(cost);
                Debug.Log("It should be there");
                currentWeapons[slot] = Instantiate(weapons[weaponType], weaponslots[slot]);
                slotTaken[slot] = true;
                activeIcons[slot].sprite = icon.sprite;
                Debug.Log("Is it not?");
            }    
        }   
    }
    public void RemoveWeapon(int slot){
        if(slotTaken[slot] == true){
            Destroy(currentWeapons[slot]);
            slotTaken[slot] = false;
            activeIcons[slot].sprite = null;
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
