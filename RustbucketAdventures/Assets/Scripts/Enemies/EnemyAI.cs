using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    private Rigidbody2D rb;         //Player rigidbody 
    public Rigidbody2D bullet2D;   //Projectile field 
    public float speed = 1.0f;      //Set speed of chase 
    public float shootRate = 1.0f;  //Shooting speed 

    public bool spotPlayer = false; //spotPlayer default false 



    public Transform weapon;        //Gun object field 
    public Transform bullet;     //Projectile object field 
    public Transform target;        //Player is target 
    public Transform[] nodes;       //Set Position For Enemy to return to / Controls Patrol Points
    public Transform eyes,          //Assign gameObjs to these variables for manipulation
                     eyeRange;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        sensePlayer();  //Function Sense Player in range
        chase();        //Chase player when sensePlayer is true
    }

    void sensePlayer()
    {
        //Draw Line for Programmer Reference (Does not show up in Game window)
        Debug.DrawLine(eyes.position, eyeRange.position, Color.cyan);
        //spotPlayer "sees" player when true
        spotPlayer = Physics2D.Linecast(eyes.position, eyeRange.position, 1 << LayerMask.NameToLayer("Player"));

    }

    void weaponShoot()
    {
        Debug.DrawLine(eyes.position, eyeRange.position, Color.red);    //Draw Line
        //If player spotted, shoot at them.  Bullet travels through line cast to hit Player
        if (spotPlayer == true)
        {
            //laserBeam = Instantiate();
        }

        //Player loses hit points with each hit.


    }

    void chase()
    {
        //The moment the enemy can "see" the player, trigger enemy chase
        if (spotPlayer == true)
        {
            //Chase the player
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
        else
        {

            //transform.eulerAngles = new Vector2(0,180);
        }
    }

    void patrol()
    {
        //Patrol between two nodes when player is out of range

    }
}