using UnityEngine;
using System.Collections;

public class PracticeDummyManager : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetButtonDown("Reset"))
        {
            ResetAllDummies();
        }
	}

    private void ResetAllDummies()
    {
        GameObject[] allDummies = GameObject.FindGameObjectsWithTag("PracticeDummy");
        for(int i = 0; i < allDummies.Length; ++i)
        {
            allDummies[i].GetComponent<PracticeDummy>().ResetDummy();
        }
    }
}
