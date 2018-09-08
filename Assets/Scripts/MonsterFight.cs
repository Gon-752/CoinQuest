using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFight : MonoBehaviour {

	public bool playerInRange;	

	 void OnTriggerEnter (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInRange = true;
			//other.gameObject.GetComponent<PlayerFight>().fight = true;
			other.gameObject.GetComponent<PlayerFight>().AddTarget(gameObject);
        }
    }
	void OnTriggerExit (Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerInRange = false;
			other.gameObject.GetComponent<PlayerFight>().RemoveTarget(gameObject);
			//other.gameObject.GetComponent<PlayerFight>().fight = false;
        }
    }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
