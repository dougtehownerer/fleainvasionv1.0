using UnityEngine;
/*used for Text objects
and to exit application
*/
using UnityEngine.UI;
/*used for scene loading as numbers instead of names instead of Application.LoadLevel("scene name")
   Scene.Manager(int)*/
using UnityEngine.SceneManagement;
using System.Collections;

public class uiManager : MonoBehaviour
{
    //need itchBar to be static unless it works how its desired without
    public int itchBar= 450; 
	public GUISkin theSkin;
    public Button[] buttons; 
    bool paused;
    bool muted;

    //depends on value of fleas, 10(basic), 20(intermediate), 50(Boss)
    public Text pointsText;
    public Text healthText;

    //will use this to calculate itch 
    public int killedEnemies;

    public int loseLimit = 200;
    public int winLimit = 50;

    /*TODO: get rid of the invokerepeating function
     when the testing and damage has been figured out
     in a way to refactor the flea points to dead fleas and not time*/
    private int loseGameThreshold;
    private int winGameThreshold;
    void Start()
	{ 
		muted = false;
		paused = false;
		killedEnemies = 0;

		loseGameThreshold = loseLimit;
		winGameThreshold = winLimit;
}
    
    // Update is called once per frame
    void Update()
    {
        if (!(SceneManager.GetActiveScene().name == "MainMenu" ||
        SceneManager.GetActiveScene().name == "DogStory" ||
        SceneManager.GetActiveScene().name == "GameOver" ||
        SceneManager.GetActiveScene().name == "WonGame"))
        {
            //enemies killed, or player kills fleas(logo of flea with bullet holes, lol)
            pointsText.text = "Fleas: " + killedEnemies;
            healthText.text = "HP: " + itchBar;

        }
        
        //LOSE Game
        if (itchBar <= loseGameThreshold)
        {
            loadGameOver();
        }
        //WIN GAME
        if (killedEnemies >= winGameThreshold)
        {
            loadWonGame();
        }
    }
    
    public void loadWonGame()
    {
		SceneManager.LoadScene(3); 
    }
    
    public void loadGameOver()
    {
        SceneManager.LoadScene(2);
    }

    public void Play()
    {
        SceneManager.LoadScene(1);
    }
    public void Pause()
    {
       if (!paused)
       {
            //activates Main Menu Button
            buttons[1].gameObject.SetActive(true);
            //activates Exit Button
            buttons[2].gameObject.SetActive(true);
            Time.timeScale = 0;
        }
       //unpause
       else if(paused)
       {
            //activates Main Menu Button
            buttons[1].gameObject.SetActive(false);
            //activates Exit Button
            buttons[2].gameObject.SetActive(false);
            Time.timeScale = 1;
       }
       paused = !paused;   
    }
    
    public void Mute()
    {
        muted = !muted;
        if (muted)
        {
            AudioListener.volume = 0;
        }
        else if (!muted)
        {
            AudioListener.volume = 1;
        }
    }
    
    /*Restarts in level 1 of the game 
     * scene 1 == level 1
     */
    public void Replay()
    {
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        /*
         * in case we go to menu from pause menu 
         * then into the first level it won't start 
         * with time.timeScale == 0
        */
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        //scene 0 == "Main Menu"
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    /*
     Dog Story displayed in DogStory
     */
    public void DogStory()
    {   
        //scene 4 == DogStory 
        SceneManager.LoadScene(4);
    }

	//public void OnGUI () {
		//GUI.skin = theSkin;
		//GUI.Label (new Rect (10, 10, 200, 200), "Score: " + killedEnemies);
		//GUI.Label (new Rect ((Screen.width/2)-75, 740, 200, 200), "Itch Bar: " + itchBar);
	//}
}

