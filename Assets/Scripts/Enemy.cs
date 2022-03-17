using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody enemyRB;
    private float zDestroy =  -10.0f;
    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyRB.AddForce(Vector3.forward * (-speed) );
        if(transform.position.z < zDestroy)
        {
            Destroy(gameObject);
        }
    }
}
