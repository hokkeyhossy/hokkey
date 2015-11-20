using UnityEngine;
using System.Collections;

public class BallMove : MonoBehaviour 
{
	public Vector3 FirstMoveForce;
	public Rigidbody myRigid;

	public GameManager myManager;
	// Use this for initialization
	void Start () 
	{
		GameObject obj=GameObject.Find("GameManagerHolder");;

		myManager = obj.GetComponent <GameManager>();
		//myRigid.AddForce(FirstMoveForce);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}

	void OnTriggerEnter(Collider other)
	{
		myManager.SetisBall(false);
		Destroy(this);
	}

}
