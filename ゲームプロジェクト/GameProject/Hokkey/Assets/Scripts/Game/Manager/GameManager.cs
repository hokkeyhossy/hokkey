using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public bool isDebug;
	public KeyCode RefreshKey;

	public GameObject Ball;
	public GameObject vBall;

	private GameObject ActiveBall;
	public Transform[] points;
	private float RespornCnt;
	private float vRespornCnt;
	public float RespornTime;
	static private bool LiveFlag;
	public int BallMax;
	public int VBallMax;

	private int BallCnt;
	private int vBallCnt;

	public Transform baseTrans;

	float MAXCnt;
	public float MaxMax;
	bool isMax;

	// Use this for initialization
	void Start () 
	{
		MAXCnt=0;
		isMax=false;

		BallCnt=0;
		vBallCnt=0;
		LiveFlag=false;
		CameraFade.StartAlphaFade(Color.black, true,2.0f, 0f,()=>ChengeFlag(true));
		RespornCnt=0;
		vRespornCnt=0;
		AudioManager.Instance.PlayBGM("BGM_TEST");
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(LiveFlag)
		{
			if(isMax&&vBallCnt<VBallMax)
			{
				if(vRespornCnt>=RespornTime)
				{
					vRespornCnt=0;
					vBallCnt++;
					int idx=Random.Range(0,points.Length);
					Instantiate(vBall,points[idx].position,points[idx].rotation);
				}

				else
				{
					vRespornCnt+=Time.deltaTime;
				}
			}

			if(BallCnt<BallMax)
			{
				if(RespornCnt>=RespornTime)
				{
					RespornCnt=0;
					BallCnt++;
					int idx=Random.Range(0,points.Length);
					Instantiate(Ball,points[idx].position,points[idx].rotation);
				}

				else
				{
					RespornCnt+=Time.deltaTime;
				}
			}

			if(Input.GetKeyDown(KeyCode.Y))
			{
				if(!isMax)
				{
					RespornTime=0.01f;
					MAXCnt=0;
					isMax=true;
				}
			}

			if(isMax)
			{
				MAXCnt++;
				if(MAXCnt>MaxMax)
				{
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

	public void SetisBall(bool value,bool isVBall)
	{
		if(!value)
		{
			if(!isVBall)
			{
				BallCnt--;
			}

			else
			{
				vBallCnt--;
			}
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

	public void GameEnd()
	{
		LiveFlag=false;
		CameraFade.StartAlphaFade(Color.black, false, 2.0f, 0f,()=>{Application.LoadLevel("Gameover");});
	}

	public void GameCrea()
	{
		LiveFlag=false;
		CameraFade.StartAlphaFade(Color.black, false, 2.0f, 0f,()=>{Application.LoadLevel("Result");});
	}
}
