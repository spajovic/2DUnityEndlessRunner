using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class enemy : MonoBehaviour
{
    private Animator myAnimator;
    [HideInInspector]
    public bool canFly;
    public GameObject playerEffect;
    public GameObject enemyBullet;
    public float timer = 3f;
    public float enemyBulletForce = 30f;
    public AudioClip hitSound;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        canFly = true;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canFly)
        {
            myAnimator.SetBool("flying", true);
        }
        if(timer <= 0)
        {
            EnemyShoots();
            timer = 4;
        }
        timer -= Time.deltaTime;
    }

    void EnemyShoots()
    {
        if(IgracAnimacija.instance.death == false)
        {
            Vector3 offset = new Vector3(transform.position.x-1.3f, transform.position.y, 0);
            GameObject newBullets = Instantiate(enemyBullet,offset,Quaternion.Euler(0f,0f,180f)) as GameObject;
            newBullets.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyBulletForce, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);
            GamePlayManager.instance.PlayerTakeDamage();
            Instantiate(playerEffect, IgracAnimacija.instance.transform.position, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
            IgracAnimacija.instance.death = true;
        }
        if(col.tag == "Bullet")
        {
            GameObject effect = Instantiate(playerEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(gameObject);
            Destroy(col.gameObject);
            Destroy(effect, 1f);
        }
    }
}
