using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    private Animator myAnimator;
    private Rigidbody2D myRigidBody;
    public GameObject playerBullet;
    public float bulletForce = 13f;
    public float timebtwnShoots = 0.333f;
    private float shootTimeStamp;
    public AudioClip bulletShoot;
    // Start is called before the first frame update
    void Start()
    {
        myAnimator = GetComponent<Animator>();
        myRigidBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(IgracAnimacija.instance.death == false)
        {
            if(Time.time >= shootTimeStamp && Input.GetKeyDown(KeyCode.D))
            {
                myAnimator.SetBool("shoot", true);
                StartCoroutine(PlayerShootsBullets(0.2f));
                shootTimeStamp = Time.time + timebtwnShoots;
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                myAnimator.SetBool("shoot", false);
            }
        }
    }

    IEnumerator PlayerShootsBullets(float startTime)
    {
        yield return new WaitForSeconds(startTime);
        Vector3 offset = new Vector3(transform.position.x +0.8f, transform.position.y-0.1f, 0);
        GameObject newBullets = Instantiate(playerBullet, offset, Quaternion.Euler(0f, 0f, 0f)) as GameObject;
        newBullets.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletForce, 0);
        AudioSource.PlayClipAtPoint(bulletShoot, transform.position, 1f);
    }
}
