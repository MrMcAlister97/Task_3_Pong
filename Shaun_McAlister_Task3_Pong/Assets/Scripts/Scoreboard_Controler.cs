using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Scoreboard_Controler : MonoBehaviour
{
    public static Scoreboard_Controler instance;
    public Text LeftScoreText;
    public Text RightScoreText;

    public int LeftScore;
    public int RightScore;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        LeftScore = RightScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //when a point has been gained, ++score(side)
    }
    public void LeftSideScore()
    {
        LeftScore +=1;
        LeftScoreText.text = LeftScore.ToString();
        //winning condish
        if(LeftScore >= 11)
        {
            SceneManager.LoadScene(2);
        }
    }

    public void RightSideScore()
    {
        RightScore +=1;
        RightScoreText.text = RightScore.ToString();
        //winning condish
        if (RightScore >= 11)
        {
            SceneManager.LoadScene(3);
        }
    }

}
