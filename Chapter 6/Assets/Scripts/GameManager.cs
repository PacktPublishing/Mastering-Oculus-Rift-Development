using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    private OVRPlayerController playerController;
    private FiringSystem firingSystem;
    [SerializeField] private GameObject menuObject;

    private void InitializePlayerReferences()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<OVRPlayerController>();
        firingSystem = player.GetComponent<FiringSystem>();
    }

	// Use this for initialization
	void Start ()
    {
	    InitializePlayerReferences();
        StartGame();
	}

    public void StartGame()
    {
        playerController.enabled = true;
        firingSystem.enabled = true;
        menuObject.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
