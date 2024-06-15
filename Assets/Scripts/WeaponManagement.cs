using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;

public class WeaponManagement : MonoBehaviour
{
    public GameObject[] weapons, currentWeapons;
    public Transform[] weaponslots;
    public bool[] slotTaken;
    public int weaponType, activeWeapon;
    
    public void Update(){
        if(Input.GetButtonDown("Fire1")){
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
                activeWeapon++;
                if(activeWeapon == currentWeapons.Length){
                activeWeapon = 0;
                }
            }           
        }
    }
    
    public void SetWeapon(int weapon){
        weaponType = weapon;
    }
    public void AddWeapon(int slot){
        if(slotTaken[slot] != true){
            currentWeapons[slot] = Instantiate(weapons[weaponType], weaponslots[slot]);
            slotTaken[slot] = true;
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
