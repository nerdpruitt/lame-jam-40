using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyTowards : MonoBehaviour
{
    public float speed, lifeTime;
    public bool OneTarget;
    public Transform point;
    Transform m_target;
    // Start is called before the first frame update
    void Start()
    {
        if(OneTarget){
            point = GameObject.FindGameObjectWithTag("Point").GetComponent<Transform>();
            m_target = point;
            point.position = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>().position;
        }
        else{
            m_target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(OneTarget){
            lifeTime -= Time.deltaTime;
        }
        if(OneTarget && lifeTime <= 0){
            Destroy(this.gameObject);
        }
        transform.position = Vector2.MoveTowards(transform.position, m_target.position, speed * Time.deltaTime);
    }
}
