using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgracAnimacija : MonoBehaviour
{
    public static IgracAnimacija instance;
    private Animator anim;
    private Rigidbody2D myrigidbody;
    public LayerMask ZemljaLayer;
    public float silaSkok = 35f;
    public Transform ZemljaPozicija;
    public float radius = 0.5f;
    private bool prizemljen;
    public GameObject playerDeathEffect;
    [HideInInspector]
    public bool death;
    public AudioClip jumpSound, bulletSound, hitSound;

    // Moze se videti u Editoru Unity-ja, ali ga ne mogu koristiti druge skripte
    [SerializeField]
    private BoxCollider2D boxColider;

    [SerializeField]
    private PolygonCollider2D polygonColider;

    // Metod Awake se koristi po paljenju aplikacije
    void IgracUzemljen()
    {
        // Proverava da li je igrac dotakao zemlja Layer
        prizemljen = Physics2D.OverlapCircle(ZemljaPozicija.position,radius,ZemljaLayer);
        
    }
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        Physics2D.IgnoreCollision(boxColider, polygonColider,true);
        MakeInstance();
    }
    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        IgracUzemljen();
        if (prizemljen && death == false)
        {
            anim.SetInteger("hodanje", 1);

        }

        // Skok 
        if (Input.GetKey(KeyCode.W))
        {
            if (prizemljen && death == false)
            {
                myrigidbody.AddForce(new Vector2(0, silaSkok));
                AudioSource.PlayClipAtPoint(jumpSound,transform.position,1f);
            }
            if (!prizemljen && death == false)
            {
                anim.SetBool("skok", true);
            }
        }
        else
        {
            anim.SetBool("skok", false);
        }
    }
    void OnCollisionEnter2D(Collision2D target)
    {
        if(target.gameObject.tag == "Box")
        {
            DiedThrougCollision();

        }
        if (target.gameObject.tag == "EnemyBullet")
        {
            GamePlayManager.instance.PlayerTakeDamage();
            Vector3 effectPosition = transform.position;
            Instantiate(playerDeathEffect, effectPosition, Quaternion.identity);
            Destroy(gameObject);
            Destroy(target.gameObject);
            death = true;
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);


        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Box" || col.tag == "Middle")
        {
            AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);
            GamePlayManager.instance.PlayerTakeDamage();
            Vector3 effectPosition = transform.position;
            Instantiate(playerDeathEffect, effectPosition, Quaternion.identity);
            Destroy(gameObject);
            Destroy(col.gameObject);
            death = true;
        }
    }
    void DiedThrougCollision()
    {
        GamePlayManager.instance.PlayerTakeDamage();
        Vector3 effectPosition = transform.position;
        Instantiate(playerDeathEffect, effectPosition, Quaternion.identity);
        Destroy(gameObject);
        death = true;
        AudioSource.PlayClipAtPoint(hitSound, transform.position, 1f);
    }

}
