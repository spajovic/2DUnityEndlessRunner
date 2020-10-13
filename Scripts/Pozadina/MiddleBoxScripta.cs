using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class MiddleBoxScripta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D col)
    {  
        if(col.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(col.gameObject);
        }
        
    }
}
