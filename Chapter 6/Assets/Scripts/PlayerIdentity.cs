using UnityEngine;
using System.Collections;

public enum Team
{
    Red,
    Blue,
    Yellow,
    Green
}

public class PlayerIdentity : MonoBehaviour
{
    public Team playerTeam;

	// Use this for initialization
	void Start ()
	{
	    playerTeam = Team.Green;
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}
}
