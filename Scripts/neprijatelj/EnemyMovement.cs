using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed = 4f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IgracAnimacija.instance.death == false)
        {
            StartCoroutine(moveEnemy());
        }
        
    }
    IEnumerator moveEnemy()
    {
        yield return new WaitForSeconds(0.7f);
        transform.Translate(Vector3.right * Time.deltaTime * enemySpeed);
    }
}
