using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public bool isDebug;
	public KeyCode RefreshKey;


	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(isDebug&&(Input.GetKeyDown(RefreshKey)))
		{
			Application.LoadLevel ("Game");
		}
	
	}
}
