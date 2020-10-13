using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZemljaSkroler : MonoBehaviour
{
    private float zemljaSpeed = -0.03f;
    private Renderer render;
    // Start is called before the first frame update
    void Start()
    {
        render = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        render.material.mainTextureOffset = new Vector2(zemljaSpeed * Time.deltaTime, 0);
    }
}
