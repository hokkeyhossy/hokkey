using UnityEngine;
using System.Collections;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager> 
{
	public float MyScore;
	public float ScoreMax;

	// Use this for initialization
	void Start () 
	{
		MyScore=0;
		if(this != Instance)
		{
			Destroy(this);
			return;
		}
	}

	public void SetScore(float Value)
	{
		MyScore=Value;
		CheckLenge();
	}

	public void AddScore(float Value)
	{
		MyScore+=Value;
		CheckLenge();
	}

	public void ResetScore()
	{
		MyScore=0;
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
}
