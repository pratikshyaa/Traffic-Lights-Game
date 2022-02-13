using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Player{
    public Image panel;
    public Text text;
}
[System.Serializable]
public class PlayerColor
{
    public Color panelColor;
    public Color textColor; 
}

public class GameController : MonoBehaviour
{
 public Text[] buttonList;
 private string playerSide;
 private int[,] rows = new int[14, 3] { { 0, 1, 2 }, { 1, 2, 3 }, { 4, 5, 6 }, { 5, 6, 7 }, { 8, 9, 10 }, { 9, 10, 11 }, { 0, 4, 8 }, { 1, 5, 9 }, { 2, 6, 10 }, { 3, 7, 11 }, { 0, 5, 10 }, { 1, 6, 11 }, { 2, 5, 8 }, { 3, 6, 9 } };
 public GameObject gameOverPanel;
 public Text gameOverText;
 public GameObject restartButton; 
 public Image[] buttonImages;
 public Button[] buttonArr; 
 public Player player1; 
 public Player player2;
 public PlayerColor activePlayerColor; 
 public PlayerColor inactivePlayerColor; 


 public void SetGameControllerReferenceOnButtons()
    {
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }
    public void Awake()
    {
        gameOverPanel.SetActive(false);
        SetGameControllerReferenceOnButtons();
        playerSide = "1"; 
        restartButton.SetActive(false);
        SetPlayerColors();
    }
     public string getPlayerSide()
     {
        return playerSide;
	 }
     public void endTurn()
     {
        for (int i = 0; i < rows.GetLength(0); i++)
        {
            if ((buttonList[rows[i, 0]].text == "Y" && buttonList[rows[i, 1]].text == "Y" && buttonList[rows[i, 2]].text == "Y" )|| (buttonList[rows[i, 0]].text == "R" && buttonList[rows[i, 1]].text == "R" && buttonList[rows[i, 2]].text == "R" )|| (buttonList[rows[i, 0]].text == "G" && buttonList[rows[i, 1]].text == "G" && buttonList[rows[i, 2]].text == "G"))

            {
                GameOver();
                return;
            }

        }
        ChangeSides();

	 }
     public void GameOver()
     {
     SetBoardInteractable(false); 
     SetGameOverText(playerSide + " Wins!");
     restartButton.SetActive(true);
     }
     public void ChangeSides()
     {
     playerSide = (playerSide == "1") ? "2" : "1";
     SetPlayerColors();
     }
     public void SetBoardInteractable(bool toggle)
    {
        for (int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponentInParent<Button>().interactable = toggle;

        }
    }

    void SetGameOverText(string value)
    {
     gameOverPanel.SetActive(true);
     gameOverText.text = value; 
	}
    void SetPlayerColors()
 {
 Player activePlayer = (playerSide == "1") ? player1 : player2;
 Player inactivePlayer = (playerSide == "1") ? player2 : player1;
 activePlayer.panel.color = activePlayerColor.panelColor;
 activePlayer.text.color = activePlayerColor.textColor;
 inactivePlayer.panel.color = inactivePlayerColor.panelColor;
 inactivePlayer.text.color = inactivePlayerColor.textColor;
 }

    public void RestartGame()
    {
     playerSide ="1";
    
     gameOverPanel.SetActive(false);
     SetBoardInteractable(true);
     for (int i = 0; i < buttonList.Length; i++)
        {
           
            buttonList[i].text="";
            buttonImages[i].GetComponent<Image>().overrideSprite = null;
            buttonList[i].GetComponentInParent<GridSpace>().SetGameCounterReference(0);
        }
        SetPlayerColors();
    restartButton.SetActive(false);
	}

}
 