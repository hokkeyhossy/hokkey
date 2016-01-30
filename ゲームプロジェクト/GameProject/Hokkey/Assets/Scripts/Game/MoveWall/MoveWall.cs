using UnityEngine;
using System.Collections;

public class MoveWall : MonoBehaviour 
{
	public Transform myTrans;
	public Vector3 MoveMin;
	public Vector3 MoveMax;

	public float MoveTime;
	private float NowTime;

	public Vector3 l_pos;

	// Use this for initialization
	void Start () 
	{
		NowTime=0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		NowTime+=Time.deltaTime;

		if(NowTime>MoveTime)
		{
			return;
		}
	
		l_pos.x=MyMath.MapValues(NowTime,0,MoveTime,MoveMin.x,MoveMax.x);
		l_pos.y=MyMath.MapValues(NowTime,0,MoveTime,MoveMin.y,MoveMax.y);
		l_pos.z=MyMath.MapValues(NowTime,0,MoveTime,MoveMin.z,MoveMax.z);

		myTrans.localPosition=l_pos;
	}
}
