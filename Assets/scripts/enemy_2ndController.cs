using UnityEngine;
using System.Collections;

public class enemy_2ndController : MonoBehaviour {

    // Use this for initialization
    //second enemy to appear 
    public float velocity;
    private Rigidbody2D myRigidbody;
    private bool moving;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    public float timeToMove;
    private float timeToMoveCounter;


    //in unity everything regarding movement has three axes
	private Vector3 moveDirection; 

    void Start ()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        timeBetweenMoveCounter = timeBetweenMove;
        timeToMoveCounter = timeToMove; 
	}
	
	// Update is called once per frame
	void Update () {
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = moveDirection;
            if(timeToMoveCounter < 0f)
            {
                moving = false;
                timeBetweenMoveCounter = timeBetweenMove;
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime;
            myRigidbody.velocity = Vector2.zero;
            if (timeBetweenMoveCounter < 0f)
            {
                moving = true;
                timeToMoveCounter = timeToMove;

                moveDirection = new Vector3(Random.Range(-1f, 1f)*velocity, Random.Range(-1f, 1f)*velocity, 0);
				
            }
        }
	
	}
}
