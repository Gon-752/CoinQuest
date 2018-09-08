using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour {

	public List<GameObject> targetList;

	public bool fight;

	public void AddTarget(GameObject target){
		if(targetList.Contains(target)){return;}
		targetList.Add(target);
		fight = true;
	}	

	public void RemoveTarget(GameObject target){
		targetList.Remove(target);
		if (targetList.Count == 0)
			fight = false;
	}

	public GameObject GetTarget(Vector3 direction){
		GameObject nearest = targetList[0];
		Debug.Log("gettarget");
		if (targetList.Count > 1){
			foreach (GameObject target in targetList)
			{
				Debug.Log("more than 1!");
				/*if(Mathf.Abs(Vector3.Distance(transform.position, target.transform.position)) < Mathf.Abs(Vector3.Distance(transform.position, nearest.transform.position))){
					nearest = target;
				}*/
				if(Vector3.Angle(direction, target.transform.position - transform.position) < 
				Vector3.Angle(direction, nearest.transform.position - transform.position)){
					
					Debug.Log(target.name + ": " + Vector3.Angle(direction, target.transform.position - transform.position) + " und "
					+ nearest.name + ": " + Vector3.Angle(direction, nearest.transform.position - transform.position) + " = "
					+ nearest.name);
					nearest = target;
				}
			}
		}
		return nearest;
	}
	
	// Use this for initialization
	void Awake () {
		targetList = new List<GameObject>();
		fight = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
