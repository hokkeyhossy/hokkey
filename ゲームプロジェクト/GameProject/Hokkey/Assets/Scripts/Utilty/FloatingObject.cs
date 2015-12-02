using UnityEngine;
using System.Collections;

public class FloatingObject : MonoBehaviour 
{
	public Transform myTrans;
	private float ypos;
	private bool isActive;

	// Use this for initialization
	void Start () 
	{
		Active();
		ypos=myTrans.position.y;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(isActive)
		{
			ypos = Mathf.Sin (Time.frameCount / 10.0f);
			ypos *= 0.01f;
			Vector3 vector = new Vector3(0.0f,ypos,0.0f);
			myTrans.position += vector;
		}
	}

	public void Active(){isActive=true;}
	public void UnActive(){isActive=false;}

}
