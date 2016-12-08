using UnityEngine;
using System.Collections;

public class AttackScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
    public void BathAttack()
    {
        BoxCollider2D bathCollider = GameObject.Find("Bathe").GetComponent<BoxCollider2D>();
        bathCollider.enabled = enabled;
        Debug.Log("Before: " + bathCollider.enabled);
    }

	public void CombAttack()
	{
		BoxCollider2D bathCollider = GameObject.Find("Comb").GetComponent<BoxCollider2D>();
		bathCollider.enabled = enabled;
		Debug.Log("Before: " + bathCollider.enabled);
	}


	public void MedicineAttack()
	{
		BoxCollider2D bathCollider = GameObject.Find("Medicine").GetComponent<BoxCollider2D>();
		bathCollider.enabled = enabled;
		Debug.Log("Before: " + bathCollider.enabled);
	}

	public void HumanAttack()
	{
		BoxCollider2D bathCollider = GameObject.Find("Human").GetComponent<BoxCollider2D>();
		bathCollider.enabled = enabled;
		Debug.Log("Before: " + bathCollider.enabled);
	}

	public void BiteAttack()
	{
		BoxCollider2D bathCollider = GameObject.Find("Bathe").GetComponent<BoxCollider2D>();
		bathCollider.enabled = enabled;
		Debug.Log("Before: " + bathCollider.enabled);
	}

	public void RolloverAttack()
	{
		BoxCollider2D bathCollider = GameObject.Find("Rollover").GetComponent<BoxCollider2D>();
		bathCollider.enabled = enabled;
		Debug.Log("Before: " + bathCollider.enabled);
	}

	public void LickAttack()
	{
		BoxCollider2D bathCollider = GameObject.Find("Lick").GetComponent<BoxCollider2D>();
		bathCollider.enabled = enabled;
		Debug.Log("Before: " + bathCollider.enabled);
	}

	public void ScratchAttack()
	{
		BoxCollider2D bathCollider = GameObject.Find("Scratch").GetComponent<BoxCollider2D>();
		bathCollider.enabled = enabled;
		Debug.Log("Before: " + bathCollider.enabled);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
