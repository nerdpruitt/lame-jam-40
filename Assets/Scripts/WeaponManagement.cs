using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManagement : MonoBehaviour
{
    public GameObject[] weapons;
    public Transform[] weaponslots;
    public bool[] slotTaken;
    // Start is called before the first frame update
    public void AddWeapon(GameObject weapon, int slot){
        if(slotTaken[slot] != true){
            Instantiate(weapons[slot], weaponslots[slot].position, weaponslots[slot].rotation);
            slotTaken[slot] = true;
        }
        
    }
}
