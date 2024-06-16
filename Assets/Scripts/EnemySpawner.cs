using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject Asteroid1, Asteroid2, Asteroid3, UFO, Alien;
    public Text waveText;
    public GameObject[] aliveEnemies;
    public int waveNum, enemyNum, increment;
    public float waitTime;
    bool canDie = false;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("NewWave", waitTime);
    }

    // Update is called once per frame
    void Update()
    {
        if(canDie == true){
            int i = 0;
            foreach(GameObject obj in aliveEnemies){
                if(obj == null){
                    i++;
                }
            }
            if(i >= aliveEnemies.Length){
                canDie = false;
                Invoke("NewWave", 5);
            }
        }       
    }

    public void NewWave(){
        waveNum++;
        waveText.text = "Wave " + waveNum.ToString();
        enemyNum += increment;
        Debug.Log("Wave " + waveNum);
        StartCoroutine(Spawn(enemyNum));
    }

    public IEnumerator Spawn(int repeat){
        int i = 0;
        while(i < repeat){
            yield return new WaitForSeconds(waitTime);
            int spawn = UnityEngine.Random.Range(1, spawnPoints.Length);
            int choose = UnityEngine.Random.Range(1, 4);
            Array.Resize(ref aliveEnemies, enemyNum);
            Debug.Log("Spawning");
            if(choose == 1){
                int r = UnityEngine.Random.Range(1, 4);
                if(r == 1){
                    aliveEnemies[i] = Instantiate(Asteroid1, spawnPoints[spawn].position, spawnPoints[spawn].rotation);
                }
                else if (r == 2){
                    aliveEnemies[i] = Instantiate(Asteroid2, spawnPoints[spawn].position, spawnPoints[spawn].rotation);
                }
                else if (r == 3){
                    aliveEnemies[i] = Instantiate(Asteroid3, spawnPoints[spawn].position, spawnPoints[spawn].rotation);
                }
                
            }
            else if(choose == 2){
                aliveEnemies[i] = Instantiate(UFO, spawnPoints[spawn].position, spawnPoints[spawn].rotation);
            }
            else if(choose == 3){
                aliveEnemies[i] = Instantiate(Alien, spawnPoints[spawn].position, spawnPoints[spawn].rotation);
            }
            i++;
            Debug.Log("Repeating");
        }
        canDie = true;        
    }
}
