using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour 
{
	public Vector3 FirstMoveForce;
	public Rigidbody myRigid;
	// Use this for initialization
	void Start () 
	{
		myRigid.AddForce(FirstMoveForce);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
