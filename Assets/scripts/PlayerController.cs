using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{


    /// <summary>
    /// should instantiate player in uiCanvas 
    /// from there i can do the damage calculations
    /// </summary>
    // Use this for initialization
    public static int itch;

    public int loseGameThreshold;
    public int winGameThreshold;

    //will be used to calculate if you win how much you saved
    //or how much you had to spend in visit to 
    public int enemyDamage;
    
    //instance of button manager script
    //to do damage to it
    public uiManager ui;


    /*TODO: decide what script to attach 
     * (gameOVerThreshold/itchThreshold) to. Also what the value should 
     be*/

    /*FigureOut why getComponent<uiManager>() didn'g work if 
     it gets set in Start the way it should, object becomes None.
     Is it not finding the object?????? why........ before and after
     compiling it seems like it does. The attributes/variables to 
     ui are accessible, no errors are flagged. */
    void Start()
    {
        /*
        itch = 450;
        //itch reaching 100 
        loseGameThreshold = 500;
        
        //itch is maintained below loseGameThreshold
        winGameThreshold = 400;
        */

        //Why doesn't it work if it is done with the getComponent???
        //the ui becomes none if it is set in the unity engine
        //NOte: THat for "Spawner" it might be a tag. so tag the ui then it shoudl work
        //ui = GameObject.Find("uiManager").GetComponent<uiManager>();
        //ui = GetComponent<uiManager>();
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (ui.fleaPoints == 100)
        //if (itch == loseGameThreshold) //this will be the players health 
        {
            Debug.Log("PlayerController: LOST THE GAME");
            ui.gameOver();
        }
        
        if (itch <= winGameThreshold)
        {
            Debug.Log("PlayerController: WON THE GAME"); 
            ui.gameWon();
        }
        */
    }
}
