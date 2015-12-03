using UnityEngine;
using System.Collections;

public class OpenWall : MonoBehaviour
{
	public Transform myTrans;
	public Vector3 MoveMin;
	public Vector3 MoveMax;
	
	public float MoveTime;
	public  float NowTime;
	
	public Vector3 m_pos;
	// Use this for initialization
	void Start ()
	{
		NowTime=0;
	}
	
	// Update is called once per frame
	void Update () 
	{

		if(NowTime>MoveTime)
		{
			return;
		}
		
		m_pos.x=MyMath.MapValues(NowTime,0,MoveTime,MoveMin.x,MoveMax.x);
		m_pos.y=MyMath.MapValues(NowTime,0,MoveTime,MoveMin.y,MoveMax.y);
		m_pos.z=MyMath.MapValues(NowTime,0,MoveTime,MoveMin.z,MoveMax.z);
		
		myTrans.localPosition=m_pos;
	}

	public void SetOpenValue(float value)
	{
		NowTime+=value;
	}
}
