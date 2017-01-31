using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class VRInputModule : BaseInputModule
{
	private PointerEventData pointerData;

	public override void Process()
	{
		Debug.Log("VRInputModule.Process()");
	}
}
