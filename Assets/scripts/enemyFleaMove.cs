using UnityEngine;
using System.Collections;

public class enemyFleaMove : MonoBehaviour {

    //GUI bounds 
    public float yPositive = 5.17f;
    private float _yPositive;
    public float yNegative = -2.56f;
    private float _yNegative;
    public float xPositive = 2.75f;
    private float _xPositive;
    public float xNegative = -3.02f;
    public float _xNegative;


    //how much health an enemy has 
    //when enemyHealth <=0 then destroy the object
    public int hitpoints = 100;
    private int enemyHealth;

    public int velocity = 20;
    private int velocityScalar;

    public float downSpeedRange = 5.0f;
    private float downSpeed;
    public float horizontalSpeedRange = 5.0f;
    private float horizontalSpeed;

    //will be used to decide how often a flea will perform its
    //attack dealing incrementing the itch meter of the dog
    private int enemyPower = 10;
    private int attackDamage;

    public float attackGapRange;
    public float attackGapLowerLimit = 4f;
    public float attackGapUpperLimit = 2f;
    private float attackGapTime;
    private float attackTimer;

    //this should be the same for the same enemy types
    private bool attacking;
    public float attackDurationLowerBound = 1f;
    public float attackDurationUpperBound = 3f;
    private float attackDuration;

    private float attackingTimer;
    //using private Animator anim
    private Rigidbody2D myRigidBody;
    
    //connect the player to the enemy through interface
    //need to ge the object first then the script
    public uiManager playerControl;
    

    /*Player attack Damage*/
    public int bathAttackDamage = 80;
    private int bathAttackHP;
	public int combAttackDamage = 60;
	private int combAttackHP;
	public int humanAttackDamage = 40;
	private int humanAttackHP;
	public int medicineAttackDamage = 100;
	private int medicineAttackHP;

	public int scratchAttackDamage = 20;
	private int scratchAttackHP;
	public int biteAttackDamage = 20;
	private int biteAttackHP;
	public int lickAttackDamage = 20;
	private int lickAttackHP;
	public int rolloverAttackDamage = 20;
	private int rolloverAttackHP;

    private float collisionTimer;
    private bool collided;

    private BoxCollider2D attackCollider;
    private int collisionDamage;
    private float collisionTimeLimit = 0.3f;

    void Start() {

        attackCollider = null;
        collided = false;
        collisionDamage = 0;
        collisionTimer = collisionTimeLimit;
        
        _xNegative = xNegative;
        _xPositive = xPositive;
        _yNegative = yNegative;
        _yPositive = yPositive;
        /*Player attacks and damage setting*/
        bathAttackHP = bathAttackDamage;   
		combAttackHP = combAttackDamage;
		humanAttackHP = humanAttackDamage;
		medicineAttackHP = medicineAttackDamage;
		scratchAttackHP = scratchAttackDamage;
		biteAttackHP = biteAttackDamage;
		lickAttackHP = lickAttackDamage;
		rolloverAttackHP = rolloverAttackDamage;
        //Enemy mechanics
        enemyHealth = hitpoints;
        velocityScalar  = velocity;
        attackDamage = enemyPower;
        attackGapTime = Random.Range(attackGapLowerLimit, attackGapUpperLimit);
        //time gap between attacks enemy will be moving 
        attackTimer = attackGapTime;
        downSpeed = generateVerticalSpeed();
        
        horizontalSpeed = generateHorizontalSpeed();
        myRigidBody = GetComponent<Rigidbody2D>();
        //so that all fleas don't look like they are sinchronized and perform
        //there attacks at different times
        attacking = false;

        //enemy will stop and deal damage
        attackDuration = Random.Range(attackDurationLowerBound, attackDurationUpperBound);
        attackingTimer = attackDuration;

        //ENEMies need access to be able damage the player
        playerControl = GameObject.Find("UIManager").GetComponent<uiManager>();
    }

    float generateHorizontalSpeed()
    {
        bool goRight = Random.Range(-5f, 5f) >= 0;
        return goRight ? Random.Range(0f, 3f) : -Random.Range(0f, 3f);
    }

    float generateVerticalSpeed()
    {
        return -Random.Range(downSpeedRange - 1, downSpeedRange + 1 );
    }


    public void performCardAttackOnFleas()
    {
        if (collided)
        {
            if (collisionTimer >= 0)
            {
                collisionTimer -= Time.deltaTime;
            }
            else
            {
                enemyHealth -= collisionDamage;
                collisionDamage = 0;
                if (attackCollider)
                {
                    if (attackCollider.enabled)
                    {
                        attackCollider.enabled = !enabled;
                    }
                    //need to make sure that you can't press other buttons while one button is pressed
                    attackCollider = null;
                }
                collided = !collided; //end collision
            }
        }
    }

    /*TODO: perform attack and initiate animation of the enememy*/
    void Update() {
        performCardAttackOnFleas();
        if (canAttack() && attackTimer <= 0)
        {
            //STOP and perform attack
            attackTimer = attackGapTime;
            myRigidBody.velocity = new Vector2(0, 0);
            attacking = true;
        }
        //else move normally don't attack where you can't 
        
        if (canAttack() && attacking)
        {
            attackPlayer();
        }
        else //(!canAttack() && !attacking)
        {
            attackTimer -= Time.deltaTime;
            myRigidBody.velocity = new Vector2(horizontalSpeed, downSpeed) * Time.deltaTime * velocityScalar;
        }

        //check if enemy flea still has live 
        //if not destroy gameObject
        checkTurnAround();
        enemyAlive();
    }
    void attackPlayer()
    {
        attackAndAnimation();
    }

    //TODO: with time add animation and audio for attack
    void attackAndAnimation()
    {
        attackingTimer -= Time.deltaTime;
        if (attackingTimer <= 0)
        {
            playerControl.itchBar -= attackDamage * 1;
            attackingTimer = attackDuration;
            attacking = !attacking;
        }
    }

    void moveIntoAttack()
    {
        myRigidBody.velocity = new Vector2(horizontalSpeed, downSpeed) * Time.deltaTime * velocityScalar;
        attackTimer -= Time.deltaTime;
        if (attackTimer <= 0)
        {
            attackTimer = attackGapTime;
            attacking = !attacking;
            myRigidBody.velocity = new Vector2(0, 0);
        }
    }

    //TODO: Optional if enemy dies perform death animation
    void enemyAlive()
    {
        if (enemyHealth <= 0)
        {
            destroyYourself();
        }
    }
    
    
    bool canAttack()
    {
        return myRigidBody.position.y <= 5.2 && myRigidBody.position.y >= -2.18 &&
            myRigidBody.position.x <= 2.8 && myRigidBody.position.x >= -3.18;
    }
    //void turn Around Vertically too

    //went past bounds
    //or is close to going over bounds
    void checkTurnAround()
    {
        //horizontally
        if (myRigidBody.position.x >= _xPositive)
        {
            if (horizontalSpeed > 0.0f)
            {
                horizontalSpeed *= -1;
            } 
        }
        if (myRigidBody.position.x <= _xNegative)
        {
            if (horizontalSpeed < 0.0f)
            {
                horizontalSpeed *= -1;
            }
        }

        //vertically 
        if (myRigidBody.position.y >= _yPositive)
        {
            if (downSpeed > 0f)
            {
                downSpeed *= -1;
            }
        }
        else if (myRigidBody.position.y <= _yNegative)
        {
            if (downSpeed < 0)
            {
                downSpeed *= -1;
            }
        }
    }
    //switchHorizontal direction of enemies on collision
    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "horizontalBound")// || collision.gameObject.tag == "enemyFlea")
        {
            Debug.Log("LeftHorizontal Bound is WOrking");
            horizontalSpeed *= -1;
        }

        //NEEEEEED TO ADD coordinate system too
        //Need to flip flea
        if (collision.gameObject.tag == "BottomBound")
        {
            Debug.Log("BOT is WOrking");
            downSpeed *= -1;
            gameObject.transform.Rotate(Vector3.right, 180);
        }

        if (collision.gameObject.tag == "UpperBound")
        {
            downSpeed *= -1;
            gameObject.transform.Rotate(Vector3.right, 180);
        }

		/*THIS is for the attack, Damage to fleas*/
		//do bath, bathDamage
		//activateBathe2D collider
		//Deactivate after health of fleas has been removed
		if (collision.gameObject.tag == "Bathe")
		{
			BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
			if (collider.enabled)
			{
				collider.enabled = !enabled;
			}
			enemyHealth = enemyHealth - bathAttackHP;
			if (enemyHealth <= 0)
			{
				destroyYourself();
			}
		}

		if (collision.gameObject.tag == "Comb")
		{
			BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
			if (collider.enabled)
			{
				collider.enabled = !enabled;
			}
			enemyHealth = enemyHealth - combAttackHP;
			if (enemyHealth <= 0)
			{
				destroyYourself();
			}
		}

		if (collision.gameObject.tag == "Human")
		{
			BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
			if (collider.enabled)
			{
				collider.enabled = !enabled;
			}
			enemyHealth = enemyHealth - humanAttackHP;
			if (enemyHealth <= 0)
			{
				destroyYourself();
			}
		}

		if (collision.gameObject.tag == "Medicine")
		{
			BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
			if (collider.enabled)
			{
				collider.enabled = !enabled;
			}
			enemyHealth = enemyHealth - medicineAttackHP;
			if (enemyHealth <= 0)
			{
				destroyYourself();
			}
		}

		if (collision.gameObject.tag == "Bite")
		{
			BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
			if (collider.enabled)
			{
				collider.enabled = !enabled;
			}
			enemyHealth = enemyHealth - biteAttackHP;
			if (enemyHealth <= 0)
			{
				destroyYourself();
			}
		}

		if (collision.gameObject.tag == "Scratch")
		{
			BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
			if (collider.enabled)
			{
				collider.enabled = !enabled;
			}
			enemyHealth = enemyHealth - scratchAttackHP;
			if (enemyHealth <= 0)
			{
				destroyYourself();
			}
		}

		if (collision.gameObject.tag == "Lick")
		{
			BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
			if (collider.enabled)
			{
				collider.enabled = !enabled;
			}
			enemyHealth = enemyHealth - lickAttackHP;
			if (enemyHealth <= 0)
			{
				destroyYourself();
			}
		}

		if (collision.gameObject.tag == "Rollover")
		{
			BoxCollider2D collider = collision.gameObject.GetComponent<BoxCollider2D>();
			if (collider.enabled)
			{
				collider.enabled = !enabled;
			}
			enemyHealth = enemyHealth - rolloverAttackHP;
			if (enemyHealth <= 0)
			{
				destroyYourself();
			}
		}
    }

    public void destroyYourself()
    {
        playerControl.killedEnemies += 1;
        Destroy(gameObject);
    }
}
