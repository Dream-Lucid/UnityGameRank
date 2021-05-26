using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class leader : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject scoreCellPrefab;
    public Button rank;

    public void PaiHangBang()
    {
        StartCoroutine(Fenshu.GetHighScore(GetHighScoreCallBack));
    }
    public void GetHighScoreCallBack(List<UserData> datas)
    {
        int i = 0;
        foreach (var data in datas)
        {
            if (i < 10)
            {
                var cell = Instantiate(scoreCellPrefab, transform);
                cell.GetComponent<rank>().SetMode(data);
                i++;
            }
        }


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
