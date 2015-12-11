using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverMAnager : MonoBehaviour 
{

	private const int Mode_Game=0;
	private const int Mode_Title=1;
	static private bool LiveFlag;
	public Image[] Item;
	private int ItemLength;
	private int NowChoiceItem;
	// Use this for initialization
	void Start () 
	{
		NowChoiceItem=0;
		ItemLength=Item.Length;
		LiveFlag=false;
		for(int i=0;i<ItemLength;i++)
		{
			Item[i].GetComponent <BlinkingObject>().UnActive();
		}
		
		Item[NowChoiceItem].GetComponent <BlinkingObject>().Active();
		AudioManager.Instance.PlayBGM("GameOverBGM");
		CameraFade.StartAlphaFade(Color.black, true,2.0f, 0f,()=>ChengeFlag(true));
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(LiveFlag)
		{
			if(Input.GetKeyDown(KeyCode.Return))
			{
				AudioManager.Instance.PlaySE("GameOverSELECT");
				LiveFlag=false;
				switch(NowChoiceItem)
				{
				case Mode_Game:
					CameraFade.StartAlphaFade(Color.black, false, 2.0f, 0f,()=>{Application.LoadLevel("Game");});
					break;
				case Mode_Title:
					CameraFade.StartAlphaFade(Color.black, false, 2.0f, 0f,()=>{Application.LoadLevel("Title");});
					break;
				}

			}

			if(Input.GetKeyDown(KeyCode.W))
			{
				AudioManager.Instance.PlaySE("GameOverSwitch");
				NowChoiceItem--;
				if(NowChoiceItem<0)
				{
					NowChoiceItem=0;
					return;
				}
				Item[NowChoiceItem].GetComponent <BlinkingObject>().Active();
				Item[NowChoiceItem+1].GetComponent <BlinkingObject>().UnActive();
			}

			if(Input.GetKeyDown(KeyCode.S))
			{
				AudioManager.Instance.PlaySE("GameOverSwitch");
				NowChoiceItem++;
				if(NowChoiceItem==ItemLength)
				{
					NowChoiceItem--;
					return;
				}
				
				Item[NowChoiceItem].GetComponent <BlinkingObject>().Active();
				Item[NowChoiceItem-1].GetComponent <BlinkingObject>().UnActive();
			}
		}
	}
	
	public static void ChengeFlag(bool Flag)
	{
		LiveFlag = Flag;
	}
}
