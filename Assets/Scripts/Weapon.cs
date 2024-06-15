using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public enum WeaponType {Machine, Shotgun, Railgun, Tesla};
public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public Transform shootPoint;
    public WeaponType weaponType;
    public int maxShots, currentShots;
    public float betweenShots;

    public void Fire(){
        if(weaponType == WeaponType.Machine){
            if (currentShots < maxShots){
                Invoke("Shoot", betweenShots);                
            }
            else if (currentShots >= maxShots){
                currentShots = 0;
            }
        }
    }
    private void Shoot(){
        if(weaponType == WeaponType.Machine){
            Instantiate(Projectile, shootPoint.position, shootPoint.rotation);
            currentShots++;
            Fire();
        }
    }
}
