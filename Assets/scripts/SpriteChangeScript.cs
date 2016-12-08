using UnityEngine;
using System.Collections;

public class SpriteChangeScript : MonoBehaviour {

    private Sprite currentSprite;
    private bool canChangeSprite = false; 
	// Use this for initialization
	void Start () {
        StartCoroutine("SpriteChangeLoop");
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("r"))
        {
            canChangeSprite = !canChangeSprite;
        }
	}

    IEnumerator SpriteChangeLoop()
    {
        yield return new WaitForSeconds(1);
        SpriteManagerScript spriteManager;
        if (canChangeSprite == true)
        {
            spriteManager = GameObject.Find("SpriteManager").GetComponent<SpriteManagerScript>();
        }
    }
}
