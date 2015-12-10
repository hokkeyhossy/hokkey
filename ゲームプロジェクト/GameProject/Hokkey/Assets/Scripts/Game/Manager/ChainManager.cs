using UnityEngine;
using System.Collections;

public class ChainManager : SingletonMonoBehaviour<ChainManager> 
{
	public float MyScore;
	public float ScoreMax;

	public float chainTime;
	private float NowTime;

	public float AlphaValue;
	
	// Use this for initialization
	void Start () 
	{
		NowTime=chainTime;
		MyScore=0;
		AlphaValue=0;
		if(this != Instance)
		{
			Destroy(this);
			return;
		}
	}

	void Update()
	{
		NowTime+=Time.deltaTime;
		AlphaValue=MyMath.MapValues(NowTime,0,chainTime,0,1);
		AlphaValue=1-AlphaValue;
		if(NowTime>chainTime)
		{
			ResetScore();
		}
	}
	
	public void SetScore(float Value)
	{
		NowTime=0;
		AlphaValue=1;
		MyScore=Value;
		CheckLenge();
	}
	
	public void AddScore(float Value)
	{
		NowTime=0;
		AlphaValue=1;
		MyScore+=Value;
		CheckLenge();
	}
	
	public void ResetScore()
	{
		MyScore=0;
		AlphaValue=0;
	}
	
	public float GetScore()
	{
		return (MyScore);
	}
	
	void CheckLenge()
	{
		if(MyScore<0)
		{
			MyScore=0;
		}
		
		if(MyScore>ScoreMax)
		{
			MyScore=ScoreMax;
		}
	}

	public float AlphaValue_()
	{
		return (AlphaValue);
	}
}
