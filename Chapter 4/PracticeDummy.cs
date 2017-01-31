using UnityEngine;
using System.Collections;

public class PracticeDummy : MonoBehaviour
{
    private Renderer nodeRenderer;

    private void Awake()
    {
        nodeRenderer = GetComponentsInChildren<Renderer>()[1];
    }

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Projectile")
        {
            OnDummyHit();
        }
    }

    private void OnDummyHit()
    {
        nodeRenderer.material.color = Color.green;
    }

    public void ResetDummy()
    {
        nodeRenderer.material.color = Color.red;
    }
}
