using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball_Controler : MonoBehaviour
{
    //reference to Rigidbody attached to game comp
    Rigidbody rb;

    [SerializeField]
    private float _speed = 8f;

    [SerializeField]
    private float _centerModifier = 1.5f;

    // Start is called before the first frame update
    void Start()
    {
        //get shortcut to rb comp
        rb = GetComponent<Rigidbody>();
        //pause ball for 2.5s
        StartCoroutine(StartBall());
    }

    // Update is called once per frame
    void Update()
    {
        //if out of screen on LEFT
        if(transform.position.x < CameraBounds.BottomLeft.x)
        {
            //give right side a point
            Scoreboard_Controler.instance.RightSideScore();
            //start round again
            StartCoroutine(StartBall());
        }

        //if out of screen on RIGHT
        if (transform.position.x > CameraBounds.TopRight.x)
        {
            //give left side a point
            Scoreboard_Controler.instance.LeftSideScore();
            //start round again
            StartCoroutine(StartBall());
        }
    }

    IEnumerator StartBall()
    {
        //set ball's location to 0 0
        transform.position = Vector3.zero; //zero means 0 on the x,y and z axs
        rb.velocity = Vector3.zero;

        yield return new WaitForSeconds(2.5f);

        //pick a random ditraction and move in the direction
        //random x and y acces
        int xDirection = Random.Range(-1, 1);

        int yDirection = Random.Range(-1, 1);

        rb.velocity = new Vector3(Mathf.Sign(xDirection), Mathf.Sign(yDirection)).normalized * _speed;
    }

    private void OnTriggerEnter(Collider hit)
    {
        // OnCollisionEnter is like walking into a door (hit solid object)
        // OnTriggerEnter is like walking into a fart (walk into a space)

        //Debug.Log(hit.gameObject.name);
        //check if hit bodders
        //Top border
        if(hit.tag == "Borders")
        {
            //Debug.Log("Top Border hit");
            Vector3 velocity = rb.velocity;
            velocity.y = -velocity.y;
            rb.velocity = velocity.normalized * _speed;
        }

        //check if hit bat
        //bat is divided into 3 sections: Top, Middle, Bottom, check where the ball hits and "bounce" accordingly.
        //left bat
        if (hit.tag == "Bats")
        {
            //Debug.Log("left bat hit");

            Vector3 velocity = rb.velocity.normalized;

            //Hits middle of the bat
            velocity.x = -velocity.x;

            // Debug.Log(transform.position.y - hit.transform.position.y);
            float offset = transform.position.y - hit.transform.position.y;

            if (offset > 0.3f)
            {
                velocity.y = 0.5f;
            }
            else if (offset < -0.3f)
            {
                velocity.y = -0.5f;
            }
            else
            {
                velocity.x *= _centerModifier;
            }

            // //Hits lower half of bat
            // if(transform.position.y - hit.gameObject.transform.position.y <-1)
            // {
            //     rb.velocity = new Vector3(8f, -8f, 0f);
            // }

            // //Hits Top half of bat
            // if (transform.position.y - hit.gameObject.transform.position.y < 1)
            // {
            //     rb.velocity = new Vector3(8f, 8f, 0f);
            // }

            rb.velocity = velocity * _speed;
        }

    }
}
