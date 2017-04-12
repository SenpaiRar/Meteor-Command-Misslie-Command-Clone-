using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
    public delegate void LaunchDelegate();
    public event LaunchDelegate LaunchEvent;
    
    public Vector3 missileTarget;
    public Transform missileOrigin;
    public GameObject missile;
    public Camera mainCamera;
    private bool canShoot;
    private int amountOfMissilesFired;
    public int AmountOfMissileCanShoot; //How many missiles does the play have before reloading
	void Start () {
        amountOfMissilesFired = 0;
        canShoot = true;
    }
	
	
	void Update () {
        if (Input.GetMouseButtonDown(0) && canShoot) //when the user hits the left mouse button
        {
            if (amountOfMissilesFired < 3)
            {
                amountOfMissilesFired += 1;
                SetTarget();
                LaunchMissile(missile.GetComponent<Missile>());
            }
            else
            {
                canShoot = false;
                StartCoroutine(Reload());
            }
         
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
    
    IEnumerator Reload()
    {
        Debug.Log("Reload!");
        yield return new WaitForSeconds(2);
        canShoot = true;
        amountOfMissilesFired = 0;
        yield break;
    }
}
