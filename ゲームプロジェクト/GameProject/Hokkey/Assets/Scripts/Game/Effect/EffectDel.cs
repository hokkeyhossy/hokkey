using UnityEngine;
using System.Collections;

public class EffectDel : MonoBehaviour 
{
	private int delCnt;
	private const int delCntMax=100;
	// Use this for initialization
	void Start () 
	{
		delCnt=0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		delCnt++;

		if(delCnt==delCntMax)
		{
			//自身を破壊する
			Destroy(this.gameObject);
		}
	}
}
