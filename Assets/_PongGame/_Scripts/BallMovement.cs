using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float movementSpeed;
    public float extraSpeedPerHit;
    public float maxSpeed;

    int hitCounter = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(this.StartBall());
    }

    void PositionBall(bool isStartingPlayer1)
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);

        if (isStartingPlayer1)
        {
            this.gameObject.transform.localPosition = new Vector3(-150, 0, 0);
        }
        else
        {
            this.gameObject.transform.localPosition = new Vector3(150, 0, 0);
        }
    }

    public IEnumerator StartBall(bool isStartingPlayer1 = true)
    {
        this.PositionBall(isStartingPlayer1);

        this.hitCounter = 0;

        yield return new WaitForSeconds(1.25f);

        if (isStartingPlayer1)
        {
            this.MoveBall(new Vector2(-1, 0));
        }
        else
        {
            this.MoveBall(new Vector2(1, 0)); 
        }
    }

    public void MoveBall(Vector2 dir)
    {
        dir = dir.normalized;

        float speed = this.movementSpeed + this.hitCounter * this.extraSpeedPerHit;

        Rigidbody2D rigidbody = this.gameObject.GetComponent<Rigidbody2D>();

        rigidbody.velocity = dir * speed;
    }

    public void IncreaseHitCounter()
    {
        if(this.hitCounter * this.extraSpeedPerHit <= this.maxSpeed)
        {
            this.hitCounter++;
        }
    }
}
