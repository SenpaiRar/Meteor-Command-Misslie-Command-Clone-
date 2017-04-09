using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public Transform missileLauncher;
    public GameObject missile;
    public Vector3 missileTarget;
    public static bool missileOut; //Has a missile been spawned already?
	void Start () {
        missileOut = false;
	}
	
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && !missileOut)
        {
            missileTarget = GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition);
            LaunchMissile();
        }
        
	}

    void LaunchMissile()
    {
        missileOut = true;
        Instantiate(missile, missileLauncher.position, Quaternion.identity);
    }
}
