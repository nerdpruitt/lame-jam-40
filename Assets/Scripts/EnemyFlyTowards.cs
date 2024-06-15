using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFlyTowards : MonoBehaviour
{
    public float speed;
    Transform m_target;
    // Start is called before the first frame update
    void Start()
    {
        m_target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, m_target.position, speed * Time.deltaTime);
    }
}
