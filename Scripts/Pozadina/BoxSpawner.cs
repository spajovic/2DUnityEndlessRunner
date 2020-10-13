using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject[] box;

    public float timer;
    public float xOsa;

    void Sponovanje()
    {
        //Instantiate vraca klon prosledjenog objekta
        //Quaternion odradjuje rotaciju, koju mi ne zelimo 
        int index = Random.Range(0,box.Length);
        Instantiate(box[index], new Vector3(xOsa,0,0),Quaternion.Euler(0,0,0));
        timer = 4f;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(timer <= 0 && IgracAnimacija.instance.death == false)
        {
            Sponovanje();
        }
        timer -= Time.deltaTime;
        
    }
}
