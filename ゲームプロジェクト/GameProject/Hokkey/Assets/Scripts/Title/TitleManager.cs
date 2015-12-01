﻿using UnityEngine;
using System.Collections;

public class TitleManager : MonoBehaviour
{
	static private bool LiveFlag;
	// Use this for initialization
	void Start () 
	{
		LiveFlag=false;
		CameraFade.StartAlphaFade(Color.black, true,2.0f, 0f,()=>ChengeFlag(true));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(LiveFlag)
		{
			if(Input.anyKeyDown)
			{
				CameraFade.StartAlphaFade(Color.black, false, 2.0f, 0f,()=>{Application.LoadLevel("Game");});
			}
		}
	}

	public static void ChengeFlag(bool Flag)
	{
		LiveFlag = Flag;
	}
}
