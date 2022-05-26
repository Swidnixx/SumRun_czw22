using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float forceScale = 1;
    private Rigidbody2D rb;
    private BoxCollider2D bc;
    private bool doubleJumped;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (OnTheGround())
            {
                SoundManager.instance.PlayOnceJump();
                doubleJumped = false;
                Vector2 jumpForce = new Vector2(0, forceScale);
                rb.velocity = jumpForce;  
            }
            else if(!doubleJumped)
            {
                Vector2 jumpForce = new Vector2(0, forceScale - 1);
                rb.velocity = jumpForce;
                doubleJumped = true;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag( "Obstacle" ) && !GameManager.instance.immortality.isActive)
        {
            PlayerKill(); 
        }

        if(collision.CompareTag("Coin"))
        {
            SoundManager.instance.PlayCoinGrab();
            Destroy(collision.gameObject);
            GameManager.instance.CoinCollected();
        }

        if(collision.CompareTag( "Immortality" ))
        {
            Destroy(collision.gameObject);
            GameManager.instance.ImmortalityCollected();
        }

        if(collision.CompareTag( "Magnet" ))
        {
            Destroy(collision.gameObject);
            GameManager.instance.MagnetCollected();
        }
    }

    private void PlayerKill()
    {
        GameManager.instance.GameOver();
    }

    private bool OnTheGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(
            transform.position,     //punkt startowy raycasta
            bc.bounds.size,         // wymiary boxa
            0,                      //k¹t boxa
            Vector2.down,           //kierunek raycasta
            1.3f,                    //d³ugoœæ raycast
            LayerMask.GetMask("Ground")
            );

        return hit.collider != null;
    }
}
