using UnityEngine;
using System.Collections;

public class MoveObject : MonoBehaviour 
{
	//---------------------------------------
	//  変数宣言
	//---------------------------------------
	public Transform myTrans;
	public Rigidbody myRigid;
	//Player Used Keycode
	public  KeyCode KEY_MOVE_RIGHT = KeyCode.D;
	public  KeyCode KEY_MOVE_LEFT = KeyCode.A;
	public  KeyCode KEY_MOVE_UP = KeyCode.W;
	public  KeyCode KEY_MOVE_DOWN = KeyCode.S;
	public  KeyCode KEY_MOVE_JUMP = KeyCode.Return;
	
	//Player Used Speed
	public  float MoveSpeed=1.0f;
	public  float SPD_JUMP=1.0f;

	private Vector3 m_moveSpeed;
	public float InertiaPow;

	// Use this for initialization
	void Start ()
	{
		m_moveSpeed=new Vector3(0,0,0);
	}

	void Update ()
	{
		if(Input.GetKey(KEY_MOVE_LEFT))
		{
			m_moveSpeed.x=-MoveSpeed;
		}
		
		if(Input.GetKey(KEY_MOVE_RIGHT))
		{
			m_moveSpeed.x=MoveSpeed;
		}
		
		if(Input.GetKey(KEY_MOVE_DOWN))
		{
			m_moveSpeed.z=-MoveSpeed;
		}
		
		if(Input.GetKey(KEY_MOVE_UP))
		{
			m_moveSpeed.z=MoveSpeed;
		}
		
		m_moveSpeed*=InertiaPow;
	}


	// Update is called once per frame
	void FixedUpdate () 
	{
		//myRigid.velocity=new Vector3(0,0,0);
		myRigid.AddForce(m_moveSpeed);
		//m_moveSpeed=new Vector3(0,0,0);

	}
}
