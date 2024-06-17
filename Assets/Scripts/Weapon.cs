using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.WSA;

public enum WeaponType {Machine, Shotgun, Launcher, Tesla};
public class Weapon : MonoBehaviour
{
    public GameObject Projectile;
    public Transform shootPoint;
    public Transform[] shootPoints;
    public WeaponType weaponType;
    public int maxShots, currentShots;
    public float betweenShots;
    public AudioSource shootsound;

    public void Fire(){
        shootsound.Play();
        if(weaponType == WeaponType.Machine || weaponType == WeaponType.Tesla){
            if (currentShots < maxShots){
                Invoke("Shoot", betweenShots);                
            }
            else if (currentShots >= maxShots){
                currentShots = 0;
            }
        }
        else if (weaponType == WeaponType.Shotgun || weaponType == WeaponType.Launcher){
            Shoot();
        }
    }
    private void Shoot(){
        if(weaponType == WeaponType.Machine || weaponType == WeaponType.Tesla){
            Instantiate(Projectile, shootPoint.position, shootPoint.rotation);
            currentShots++;
            Fire();
        }
        else if (weaponType == WeaponType.Shotgun){
            foreach(Transform point in shootPoints){
                Instantiate(Projectile, point.position, point.rotation);
            }
        }
        else if (weaponType == WeaponType.Launcher){
            Instantiate(Projectile, shootPoint.position, shootPoint.rotation);
        }
    }
}
