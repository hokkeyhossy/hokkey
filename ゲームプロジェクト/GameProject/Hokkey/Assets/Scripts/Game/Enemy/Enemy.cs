using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour 
{
	private GameObject Wall1;
	private GameObject Wall2;

	private OpenWall wall1;
	private OpenWall wall2;

	// Use this for initialization
	void Start () 
	{
		Wall1=GameObject.Find("Wall1");
		Wall2=GameObject.Find("Wall2");

		wall1=Wall1.gameObject.GetComponent<OpenWall>();
		wall2=Wall2.gameObject.GetComponent<OpenWall>();
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnCollisionEnter(Collision other)
	{
		if(other.gameObject.tag=="Ball")
		{
			wall1.SetOpenValue(1);
			wall2.SetOpenValue(1);
		}
	}
}
