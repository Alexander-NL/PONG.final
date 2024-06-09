using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ballin : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public bool InMenu = false;
    private Rigidbody2D rb2d;
    public AudioSource BallSound;
    public AudioSource PlayerSound;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
        if(InMenu ==  true){
            Invoke("GoBall", 0); 
        }else{
            Invoke("GoBall", 2); 
        }
    }
    public void GoBall()
    {
        transform.position = new Vector2(0,0);
        rb2d.velocity = Vector2.zero;
        float rand = Random.Range(0, 2); 
        if (rand < 1)
        { 
            rb2d.AddForce(new Vector2(0.05f, -0.05f));

        }
        else
        {
            rb2d.AddForce(new Vector2(-0.05f, -0.05f));
        }
    
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y) + (coll.collider.attachedRigidbody.velocity.y);
            rb2d.velocity = vel;
            PlayerSound.Play();
        }
        BallSound.Play();
        float r = Random.Range(0f, 1f);
        float g = Random.Range(0f, 1f);
        float b = Random.Range(0f, 1f);
        Sprite.color = new Color(r, g, b);
    }

    public void RestartBall()
    {
        transform.position = new Vector2(0,0);
        rb2d.velocity = Vector2.zero;
        Invoke("GoBall", 2);
    }

    public void ResetBall()
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

}