using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    //public static int collectiblecount;
    //public static int collectiblevalue;
    //public Transform Player;
    //public Text PillCount;
    //public Text scoretext;
    //public Text highscore;
    //public int Maxscore;

    public Text gamescore;
    public Text scoretext;
    public Text highscore;
    public int maxscore;

    void Start()
    {
        //collectiblecount = 0;
        //collectiblevalue = 0;
        //highscore.text = PlayerPrefs.GetInt("highscore", 0).ToString();
        highscore.text = PlayerPrefs.GetInt("highscore", 0).ToString();
    }

    void Update()
    {

        //Maxscore = Mathf.RoundToInt(collectiblecount + Mathf.Abs(Player.position.y));
        //scoretext.text = Maxscore.ToString();

        //if (Maxscore > PlayerPrefs.GetInt("highscore", 0))
        //{
        //    PlayerPrefs.SetInt("highscore", Maxscore);
        //    highscore.text = Maxscore.ToString();
        //}

        //PlayerPrefs.Save();

        maxscore = Score.scoreValue;

        scoretext.text = gamescore.text;

        if (maxscore > PlayerPrefs.GetInt("highscore", 0))
        {
            PlayerPrefs.SetInt("highscore", maxscore);
            highscore.text = maxscore.ToString();
        }

        PlayerPrefs.Save();
    }

}
