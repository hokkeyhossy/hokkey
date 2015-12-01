using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public bool isDebug;
	public KeyCode RefreshKey;
	public GameObject Ball;
	private GameObject ActiveBall;
	private bool isBall;
	public Transform[] points;
	private float RespornCnt;
	public float RespornTime;
	static private bool LiveFlag;
	private int BallMax;

	int BallCnt;

	public Transform baseTrans;

	float MAXCnt;
	float MaxMax;
	bool isMax;

	// Use this for initialization
	void Start () 
	{
		MAXCnt=0;
		MaxMax=3;
		isMax=false;


		BallMax=2;
		BallCnt=0;
		LiveFlag=false;
		CameraFade.StartAlphaFade(Color.black, true,2.0f, 0f,()=>ChengeFlag(true));
		RespornCnt=0;
		isBall=false;
		AudioManager.Instance.PlayBGM("BGM_TEST");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(LiveFlag)
		{
			if(BallCnt<BallMax)
			{
				if(RespornCnt>=RespornTime)
				{
					RespornCnt=0;
					isBall=true;
					BallCnt++;
					int idx=Random.Range(0,points.Length);
					Instantiate(Ball,points[idx].position,points[idx].rotation);
				}

				else
				{
					RespornCnt+=Time.deltaTime;
				}
			}

			if(isDebug&&(Input.GetKeyDown(RefreshKey)))
			{
				LiveFlag=false;
				CameraFade.StartAlphaFade(Color.black, false, 2.0f, 0f,()=>{Application.LoadLevel("Result");});
			}

			if(Input.GetKeyDown(KeyCode.P))
			{
				if(!isMax)
				{
					BallMax=50;
					RespornTime=0.1f;
					MAXCnt=0;
					isMax=true;
				}

				MAXCnt++;
				if(MAXCnt>MaxMax)
				{
					BallMax=2;
					RespornTime=0.5f;
					MAXCnt=0;
					isMax=false;
				}
			}


		}
	}

	public static void ChengeFlag(bool Flag)
	{
		LiveFlag = Flag;
	}

	public void SetisBall(bool value)
	{
		isBall=value;

		if(!value)
		{
			BallCnt--;
		}
	}

	public Transform BaseTrans_()
	{
		return (baseTrans);
	}

	public void SetBallMax(int Max)
	{
		BallMax=Max;
	}
}
