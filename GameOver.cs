using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    
    [SerializeField] Text gameOverText;

    public void EndGame()
    {
        gameOverText.text = "Game Over!";
    }
}
