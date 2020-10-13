using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kretanjeprepreka : MonoBehaviour
{
    private IgracAnimacija igrac;
    public float boxSpeed = 14f;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(IgracAnimacija.instance.death)
        {

        }
        else
        {
            StartCoroutine(KretnjaPrepreke());
        }
            
        
    }
    IEnumerator KretnjaPrepreke()
    {
        // ovo nista ne razumem SOURCE (StackOverflow)
        yield return new WaitForSeconds(0.9f);
        transform.Translate(Vector3.left*Time.deltaTime * boxSpeed);
    }
}
