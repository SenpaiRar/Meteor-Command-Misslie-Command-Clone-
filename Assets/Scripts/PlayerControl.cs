using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {
    public Transform missileOrigin;
    public GameObject missile;
    public Vector3 missileTarget;
    public static bool missileOut; //Has a missile been spawned already?
	void Start () {
        missileOut = false;
	}
	
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && !missileOut)
        {
            missileTarget = new Vector3(GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).x, GameObject.Find("Main Camera").GetComponent<Camera>().ScreenToWorldPoint(Input.mousePosition).y,0);
            
            LaunchMissile();
        }
        
	}

    void LaunchMissile()
    {
        missileOut = true;
        Instantiate(missile, missileOrigin.position, Quaternion.identity);
    }
}
