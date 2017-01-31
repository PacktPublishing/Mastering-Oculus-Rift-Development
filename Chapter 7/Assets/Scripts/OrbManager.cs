using UnityEngine;
using System.Collections;

public class OrbManager : MonoBehaviour
{
    private int totalOrbs;
    [SerializeField]
    private Transform lookTransform;

    private void AddOrb()
    {
        Debug.Log("Orb collected!");
        totalOrbs++;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.collider.tag == "EnergyOrb")
        {
            AddOrb();
            Destroy(hit.gameObject);
        }
    }

    private void ActivateWall()
    {
        if (totalOrbs == 0)
            return;

        Ray ray = new Ray(lookTransform.position, lookTransform.forward);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.collider.tag == "DynamicWall")
            {
                DynamicWall wall = hit.collider.GetComponent<DynamicWall>();
                int orbsToDeposit = Mathf.Min(totalOrbs, wall.remainingCost);
                wall.DepositOrbs(orbsToDeposit, GetComponent<PlayerIdentity>().playerTeam);
                totalOrbs -= orbsToDeposit;
            }
        }
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.F))
        {
            ActivateWall();
        }
	}
}
