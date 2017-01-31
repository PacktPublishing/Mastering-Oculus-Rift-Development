using UnityEngine;
using System.Collections;

public class PracticeDummy : MonoBehaviour
{
    private Renderer nodeRenderer;
    [SerializeField]
    private GameObject energyOrbPrefab;
    private float cooldownTimer = 0;

    private void Awake()
    {
        nodeRenderer = GetComponentsInChildren<Renderer>()[1];
    }

    private void OnCollisionEnter(Collision collisionInfo)
    {
        if(collisionInfo.collider.tag == "Projectile")
        {
            OnDummyHit();
        }
    }

    private void Update()
    {
        if(cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
        else if(nodeRenderer.material.color == Color.green)
        {
            ResetDummy();
        }
    }

    private void OnDummyHit()
    {
        if (nodeRenderer.material.color == Color.green)
            return;

        nodeRenderer.material.color = Color.green;
        SpawnOrb();
        cooldownTimer = 15f;
    }

    public void ResetDummy()
    {
        nodeRenderer.material.color = Color.red;
    }

    private void SpawnOrb()
    {
        GameObject newOrb = (GameObject)Instantiate(energyOrbPrefab, transform.position, transform.rotation);
        newOrb.transform.Translate(Vector3.up * 2.5f);

        float xForce = Random.Range(-1f, 1f);
        float zForce = Random.Range(-1f, 1f);
        newOrb.GetComponent<Rigidbody>().AddForce(new Vector3(xForce, 1f, zForce), ForceMode.Impulse);
    }
}
