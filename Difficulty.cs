using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    public int difficulty;
    [SerializeField] Text difText;

    // Start is called before the first frame update
    void Start()
    {
        difficulty = 1;
        difText.text = "Easy";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q)) {
            if (difficulty == 1)
            {
                difficulty = 2;
                difText.text = "Hard";
            }
            else if (difficulty == 2)
            {
                difficulty = 3;
                difText.text = "Expert";
            }
            else if (difficulty == 3)
            {
                difficulty = 1;
                difText.text = "Easy";
            }
        }

    }

    // for debugging
    public void GetDif()
    {
        Debug.Log(difficulty);
    }
}
