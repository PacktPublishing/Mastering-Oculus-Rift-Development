using UnityEngine;
using System.Collections;

public class StressTestSystem : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        StartCoroutine(GenerateRandomNumbers(1000000));
	}
	
	// Update is called once per frame
	void Update ()
    {
	    
	}

    private IEnumerator GenerateRandomNumbers(int numberCount)
    {
        float[] randomNumbers = new float[numberCount];
        for(int i = 0; i < numberCount; ++i)
        {
            randomNumbers[i] = Random.Range(0f, 100f);

            // Yield every thousand iterations
            if (i % 1000 == 0) yield return null;
        }
    }
}
