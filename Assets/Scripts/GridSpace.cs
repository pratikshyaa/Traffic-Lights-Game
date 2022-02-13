using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GridSpace : MonoBehaviour
{
	public Sprite[] spriteList;
	public Button button;
	public Text buttonText; 
	public string playerSide;
	public string color;
	public Sprite yellow;
	public Sprite green;
	public Sprite red;
	public Sprite none;
	private int counter = 0; 
	public Image buttonImage;
	private GameController gameController; 


	public void SetSpace()
	{
		Image image = buttonImage.GetComponent<Image>();
		if(counter < 3)
		{
			if(counter == 0)
			{
				buttonText.text = "G";
				image.overrideSprite = green;
			}
			else if(counter == 1)
			{
				buttonText.text = "Y";
				image.overrideSprite = yellow;
			}
			else
			{
				buttonText.text = "R";
				image.overrideSprite = red;
				button.interactable= false; 
			}
			counter++;
			gameController.endTurn(); 
		}
	}
	public void SetGameControllerReference(GameController controller)
	{
		gameController = controller; 
	}
	public void SetGameCounterReference(int counter)
    {
        this.counter = counter;
    }
}
