/************************************************************************************
Filename    :   ONSPAudioSource.cs
Content     :   Interface into the Oculus Native Spatializer Plugin
Created     :   September 14, 2015
Authors     :   Peter Giokaris
Copyright   :   Copyright 2015 Oculus VR, Inc. All Rights reserved.

Licensed under the Oculus VR Rift SDK License Version 3.1 (the "License"); 
you may not use the Oculus VR Rift SDK except in compliance with the License, 
which is provided at the time of installation or download, or which 
otherwise accompanies this software in either electronic or hard copy form.

You may obtain a copy of the License at

http://www.oculusvr.com/licenses/LICENSE-3.1 

Unless required by applicable law or agreed to in writing, the Oculus VR SDK 
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
************************************************************************************/

#if UNITY_5 && !UNITY_5_0 && !UNITY_5_1
// The spatialization API is only supported by the final Unity 5.2 version and newer.
// If you get script compile errors in this file, comment out the line below.
#define ENABLE_SPATIALIZER_API
#endif

using UnityEngine;
using System.Collections;

public class ONSPAudioSource : MonoBehaviour
{
#if ENABLE_SPATIALIZER_API
	// Public

	[SerializeField]
	private bool enableSpatialization = true;
	public  bool EnableSpatialization
	{
		get
		{
			return enableSpatialization;
		}
		set
		{
			enableSpatialization = value;
		}
	}

	[SerializeField]
	private float gain = 0.0f;
	public  float Gain
	{
		get
		{
			return gain;
		}
		set
		{
			gain = Mathf.Clamp(value, 0.0f, 24.0f);
		}
	}
	
	[SerializeField]
	private bool useInvSqr = false;
	public  bool UseInvSqr
	{
		get
		{
			return useInvSqr;
		}
		set
		{
			useInvSqr = value;		
		}
	}

	[SerializeField]
	private float near = 1.0f;
	public float Near
	{
		get
		{
			return near;
		}
		set
		{
			near = Mathf.Clamp(value, 0.0f, 1000000.0f);
		}
	}

	[SerializeField]
	private float far = 10.0f;
	public float Far
	{
		get
		{
			return far;
		}
		set
		{
			far = Mathf.Clamp(value, 0.0f, 1000000.0f);
		}
	}

	[SerializeField]
	private bool disableRfl = false;
	public  bool DisableRfl
	{
		get
		{
			return disableRfl;
		}
		set
		{
			disableRfl = value;
		}
	}

#endif

	/// <summary>
	/// Awake this instance.
	/// </summary>
	void Awake()
	{
		// We might iterate through multiple sources / game object
		var source = GetComponent<AudioSource>();
		SetParameters(ref source);
	}

	/// <summary>
	/// Start this instance.
	/// </summary>
    void Start()
    {
    }

	/// <summary>
	/// Update this instance.
	/// </summary>
    void Update()
    {
		// We might iterate through multiple sources / game object
		var source = GetComponent<AudioSource>();
 		SetParameters(ref source);	
    }

	/// <summary>
	/// Sets the parameters.
	/// </summary>
	/// <param name="source">Source.</param>
	public void SetParameters(ref AudioSource source)
	{
#if ENABLE_SPATIALIZER_API 

        // Check to see if we should disable spatializion
        if ((Application.isPlaying == false) || 
            (AudioListener.pause == true) || 
            (source.isPlaying == false) ||
            (source.isActiveAndEnabled == false)
           )
        {
            source.spatialize = false;
            return;
        }
        else
        {
            source.spatialize = enableSpatialization;
        }

		source.SetSpatializerFloat(0, gain);
		// All inputs are floats; convert bool to 0.0 and 1.0
		if(useInvSqr == true)
			source.SetSpatializerFloat(1, 1.0f);
		else
			source.SetSpatializerFloat(1, 0.0f);

		source.SetSpatializerFloat(2, near);
		source.SetSpatializerFloat(3, far);

		if(disableRfl == true)
			source.SetSpatializerFloat(4, 1.0f);
		else
			source.SetSpatializerFloat(4, 0.0f);
		
#endif
	}
		
}
