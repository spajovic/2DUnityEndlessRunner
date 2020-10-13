using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField]
    private Transform[] enemy;
    [SerializeField]
    private Transform enemyParent;
    public float timer = 3f;
    [SerializeField]
    private float minimumY, maximumY,positionX;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IgracAnimacija.instance.death == false)
        {
            if (timer <= 0)
            {
                SpawnEnemy(true);
            }
            timer -= Time.deltaTime;
        }

        
    }

    void SpawnEnemy(bool started)
    {
        if(started == true)
        {
            var index = Random.Range(0, enemy.Length);
            Vector3 enemyPosition = new Vector3(positionX, Random.Range(minimumY,maximumY), 0);
            Transform createEnemy = (Transform)Instantiate(enemy[index], enemyPosition, Quaternion.Euler(180f,0f,180f));
            createEnemy.parent = enemyParent;
            timer = 3f;
        }
    }
}
