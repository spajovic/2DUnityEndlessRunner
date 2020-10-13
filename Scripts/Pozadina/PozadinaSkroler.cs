using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PozadinaSkroler : MonoBehaviour
{
    private MeshRenderer mesh;
    public float speed = -1f;

    // Start is called before the first frame update
    void Start()
    {
        mesh = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Time.deltatime se koristi za "optimizaciju", jer broj frejmova zavisi od jacine racunara
        // New Vector2 se koristi za primenjivanje "sile" u odredjenom smeru
        if(IgracAnimacija.instance.death == false)
        {
            mesh.material.mainTextureOffset -= new Vector2(speed * Time.deltaTime, 0);
        }
    }
}
