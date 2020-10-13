using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class EnemyDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Enemy")
        {
            Destroy(col.gameObject);
        }
        if(col.tag == "Box")
        {
            Destroy(col.gameObject);
        }
    }
}
