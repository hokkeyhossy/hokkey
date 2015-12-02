using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BlinkingObject : MonoBehaviour
{
	public float Interval;
	public Image myTrans;

	private float InvisibleMax=255;
	private float InvisibleMin=0;
	private float InvisibleNow;
	private float TimeCnt;
	private bool isTrue;

	// Use this for initialization
	void Start ()
	{
		isTrue=true;
		InvisibleNow=myTrans.color.a;
		TimeCnt=0;
	}
	
	// Update is called once per frame
	void Update ()
	{
		float baseNum=1;
		if(!isTrue){baseNum*=-1;}

		TimeCnt+=baseNum;

		if(TimeCnt>Interval||TimeCnt<0)
		{
			TimeCnt-=baseNum;
			isTrue=!isTrue;
		}

		InvisibleNow=MyMath.MapValues(TimeCnt,0,Interval,InvisibleMin,InvisibleMax);
		myTrans.color=new Color32(255,255,255,(byte)InvisibleNow);
	}
}
