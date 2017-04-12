using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public delegate void LaunchDelegate();
    public event LaunchDelegate LaunchEvent;

    public Vector3 missileTarget;
    public Transform missileOrigin;
    public GameObject missile;
    public Camera mainCamera;
    public static bool isMissleFired;
	
	void Start () {
        isMissleFired = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0) && !isMissleFired) //when the user hits the left mouse button
        {
            SetTarget(); 
            
            LaunchMissile(missile.GetComponent<Missile>());
        }
    }

    void LaunchMissile (Missile Projectile)
    {

        Instantiate(Projectile, missileOrigin.position, Quaternion.identity);

        if(LaunchEvent != null)
        {
            LaunchEvent();
        }
        
    }

    void SetTarget () //Get the point where the mouse cursor is at, and make that the target
    {
        missileTarget.x = mainCamera.ScreenToWorldPoint(Input.mousePosition).x;
        missileTarget.y = mainCamera.ScreenToWorldPoint(Input.mousePosition).y;
        missileTarget.z = 0;
    }
}
