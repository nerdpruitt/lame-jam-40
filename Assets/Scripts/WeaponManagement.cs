using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    public GameObject[] weapons, currentWeapons;
    public Transform[] weaponslots;
    public bool[] slotTaken;
    public int weaponType;
    // Start is called before the first frame update
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
}
