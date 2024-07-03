using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public Rigidbody2D rigidbody2D;
    public float ballSpeed;
    public Vector2 LastVelocity;
    public Movement LeftPlayer;
    public Movement RightPlayer;
    public UI_controller controller;
    private int LeftPlayerScore;
    private int RightPlayerScore;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        SendBallInRandomDirection();
    }
    public void SendBallInRandomDirection()
    {
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.isKinematic = true;
        transform.position = Vector3.zero;
        rigidbody2D.isKinematic = false;
        rigidbody2D.velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f)).normalized * ballSpeed;
        LastVelocity = rigidbody2D.velocity;
        LeftPlayer.speed = LeftPlayer.defaultSpeed;
        RightPlayer.speed = RightPlayer.defaultSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Space))
        {
            SendBallInRandomDirection();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2D.velocity = Vector2.Reflect(LastVelocity, collision.contacts[0].normal);
        LastVelocity = rigidbody2D.velocity *= 1.1f;
        LeftPlayer.speed *= 1.1f;
        RightPlayer.speed *= 1.1f;
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(transform.position.x < 0)
        {
            RightPlayerScore++;
            controller.SetRightPlayerScored(RightPlayerScore.ToString());
            
            Debug.Log("Right Player Scored");
        }
        if (transform.position.x > 0)
        {
            LeftPlayerScore++;
            controller.SetLeftPlayerScored(LeftPlayerScore.ToString());
            Debug.Log("Left Player Scored");
        }
        SendBallInRandomDirection();
    }
}
