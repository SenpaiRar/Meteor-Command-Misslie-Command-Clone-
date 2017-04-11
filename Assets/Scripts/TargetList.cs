﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class TargetList : MonoBehaviour {
    GameObject MasterCity;
    public List<Vector3> cityPositions = new List<Vector3>();
    public Vector3[] cityVecs;

    void Start () {
        
        foreach (Transform item in GameObject.Find("Cities").GetComponentInChildren<Transform>())
        {
            cityPositions.Add(item.position);
        }
        cityVecs = cityPositions.ToArray();
	}
	

	// Update is called once per frame
	void Update () {
	
	}
}
