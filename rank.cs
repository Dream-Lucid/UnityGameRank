using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class rank : MonoBehaviour
{


    public Text nameText;
    public Text scoreText;

    public void SetMode(UserData data)
    {
        nameText.text = data.userName;
        scoreText.text = data.score + "分";
    }
}
