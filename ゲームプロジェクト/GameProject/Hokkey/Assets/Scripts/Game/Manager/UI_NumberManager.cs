using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UI_NumberManager : MonoBehaviour 
{
	public Sprite[] NumberTexture;
	public Image[] NumberImage;
	public float MaxNumber;

	public float NowNumber;
	private int NumberLength;
	// Use this for initialization
	void Start ()
	{
		//NowNumber=0;
		NumberLength=NumberImage.Length;
	}

	void Update()
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
			
			num = (int)(NowNumber % (n1) / (n2));
			
			NumberImage[n].sprite=NumberTexture[num];
		}
	}

	public void SetNum(float Num)
	{
		if(Num>MaxNumber){return;}

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
			
			num = (int)(Num % (n1) / (n2));
			
			NumberImage[n].sprite=NumberTexture[num];
		}
		NowNumber=Num;
	}

	public void AddNum(float Num)
	{
		NowNumber=Num+NowNumber;
		if(NowNumber>MaxNumber)
		{
			NowNumber=MaxNumber;
		}

		if(NowNumber<0)
		{
			NowNumber=0;
		}
		
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
			
			num = (int)(Num % (n1) / (n2));
			
			NumberImage[n].sprite=NumberTexture[num];
		}
	}
}
