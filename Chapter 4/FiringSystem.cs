using UnityEngine;
using System.Collections;

public class FiringSystem : MonoBehaviour
{
    [SerializeField]
    private GameObject projectilePrefab;
    private float projectileForce = 20f;

    [SerializeField]
    private Transform lookTransform;

	// Use this for initialization
	void Start ()
    {
	    
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Fire1"))
        {
            FireProjectile();
        }
	}

    private void FireProjectile()
    {
        GameObject newProjectile = Instantiate(projectilePrefab);
        newProjectile.transform.position = lookTransform.position + transform.forward;
        newProjectile.transform.rotation = lookTransform.rotation;

        Rigidbody rigidbody = newProjectile.GetComponent<Rigidbody>();
        rigidbody.AddForce(newProjectile.transform.forward * projectileForce, ForceMode.Impulse);
        Destroy(newProjectile, 10);
    }
}
