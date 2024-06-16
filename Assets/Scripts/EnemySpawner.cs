using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject Normal, Path, Shooter;
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
                Invoke("NewWave", 5);
            }
        }       
    }

    public void NewWave(){
        canDie = false;
        waveNum++;
        enemyNum += increment;
        StartCoroutine(Spawn(enemyNum));
    }

    public IEnumerator Spawn(int repeat){
        int i = 0;
        while(i < repeat){
            yield return new WaitForSeconds(waitTime);
            int spawn = Random.Range(1, spawnPoints.Length);
            int choose = Random.Range(1, 4);
            if(choose == 1){
                Instantiate(Normal, spawnPoints[spawn].position, spawnPoints[spawn].rotation);
            }
            else if(choose == 2){
                Instantiate(Path, spawnPoints[spawn].position, spawnPoints[spawn].rotation);
            }
            else if(choose == 3){
                Instantiate(Shooter, spawnPoints[spawn].position, spawnPoints[spawn].rotation);
            }
            i++;
        }
        canDie = true;        
    }
}
