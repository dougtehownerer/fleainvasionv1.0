using UnityEngine;
using System.Collections;

public class FleaSpawner : MonoBehaviour {
    public GameObject []enemies;
    // Use this for initialization
    public int enemyNumber; 
    public float minPosition = -1f;
    public float maxPosition = 1f;
    //spawn rate
    public float delayTimer = 1f;
    private float timer;
	void Start () {
        timer = delayTimer; 
	}
	
	// Update is called once per frame
	void Update () {

        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            timer = delayTimer; 
            Vector3 spawnedPosition = new Vector3(Random.Range(minPosition, maxPosition), transform.position.y, transform.position.z);
            Instantiate(enemies[enemyNumber], spawnedPosition, transform.rotation);

        }
    }
}
