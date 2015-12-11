using UnityEngine;
using System.Collections;

public class ChainManager : SingletonMonoBehaviour<ChainManager> 
{
	public float MyScore;
	public float ScoreMax;

	public float chainTime;
	private float NowTime;

	public float AlphaValue;

	public float MaxCHain;
	
	// Use this for initialization
	void Start () 
	{
		NowTime=chainTime;
		MyScore=0;
		MaxCHain=0;
		AlphaValue=0;
		if(this != Instance)
		{
			Destroy(this.gameObject);
			return;
		}
		DontDestroyOnLoad(this.gameObject);
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
		if(Value>MaxCHain){MaxCHain=Value;}
		MyScore=Value;
		CheckLenge();
	}
	
	public void AddScore(float Value)
	{
		NowTime=0;
		AlphaValue=1;
		MyScore+=Value;
		if(MyScore>MaxCHain){MaxCHain=MyScore;}
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
	public float GetMaxScore()
	{
		return (MaxCHain);
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
