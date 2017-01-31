using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private Transform lookTransform;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.Translate(lookTransform.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.Translate(-lookTransform.forward * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.Translate(-lookTransform.right * Time.deltaTime);
        }
	    if (Input.GetKey(KeyCode.D))
	    {
	        gameObject.transform.Translate(lookTransform.right*Time.deltaTime);
	    }

	    if (Input.GetKeyDown(KeyCode.Space))
	    {
	        Teleport();
	    }
	}

    private void Teleport()
    {
        Ray ray = new Ray(lookTransform.position, lookTransform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            gameObject.transform.position = hit.point;
            gameObject.transform.Translate(0f, 1.7f, 0f);
        }
    }
}
