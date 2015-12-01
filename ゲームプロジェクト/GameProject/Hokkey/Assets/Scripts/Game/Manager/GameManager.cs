using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public bool isDebug;
	public KeyCode RefreshKey;
	public GameObject Ball;
	private GameObject ActiveBall;
	private bool isBall;
	public Transform[] points;


	// Use this for initialization
	void Start () 
	{
		isBall=false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!isBall)
		{
			isBall=true;
			int idx=Random.Range(0,points.Length);
			Instantiate(Ball,points[idx].position,points[idx].rotation);
		}

		if(isDebug&&(Input.GetKeyDown(RefreshKey)))
		{
			Application.LoadLevel ("Game");
		}
	
	}

	public void SetisBall(bool value)
	{
		isBall=value;
	}
}
