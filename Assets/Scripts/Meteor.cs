using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Meteor : MonoBehaviour {
    private Vector3 activeTarget = new Vector3(100,100,100);
    private Vector3[] targets;
    public float speed;
    private Vector3 dirToTarget;
    
    void Start () {
        targets = GameObject.Find("Main Camera").GetComponent<TargetList>().cityVecs;
        //set list targets to a list in a script that holds each city position
        foreach (var item in targets)
        {
            if(Vector3.Distance(transform.position,item) < Vector3.Distance(transform.position,activeTarget))//gets the target thats the closest to the meteor at spawn
            {
                activeTarget = item;
            }

        }

    }
	
	void Update () {

        if(Vector3.Distance(transform.position,activeTarget) > 5)
        {
            transform.position = Vector3.MoveTowards(transform.position, activeTarget, speed * Time.deltaTime);
        }
       
    }
}
