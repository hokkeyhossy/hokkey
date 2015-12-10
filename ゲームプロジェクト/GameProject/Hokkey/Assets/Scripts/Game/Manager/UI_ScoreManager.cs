using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_ScoreManager : MonoBehaviour 
{
	public Sprite[] NumberTexture;
	public Image[] NumberImage;

	private int NumberLength;
	// Use this for initialization
	void Start ()
	{
		NumberLength=NumberImage.Length;
	}
	
	// Update is called once per frame
	void Update () 
	{
		int num;

		for (int n = 0; n < NumberLength; n++) 
		{
			float n1,n2;
			n1 = 1;
			n2 = 1;

			for(int nn = 0; nn <= n; nn++)
			{
				n1 *= 10;
				if(nn > 0)
				{
					n2 *= 10;
				}
			}

			float Score=ScoreManager.Instance.GetScore();

			num = (int)(Score % (n1) / (n2));
			
			NumberImage[n].sprite=NumberTexture[num];
		}
	}
}
