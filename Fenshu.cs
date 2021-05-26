using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LitJson;
using UnityEngine.Networking;
using UnityEngine.Events;

public class UserData
{
    public string userName;
    public string score;
    public UserData(string userName, string score)
    {
        this.userName = userName;
        this.score = score;
    }
}



public class Fenshu : MonoBehaviour
{
    private const string url = "http://dreamlo.com/lb/";
    private const string prvateCode = "TSlvU3GypUmA0kQT1-rRIAqq8VzBGdlk2e-crnq5XmXQ";
    private const string publicCode = "60a3960a8f40bb71f0c7fe85";

  

    public static IEnumerator CreateNewHighScore(string userName, string score)
    {
        UnityWebRequest request = UnityWebRequest.Get(url + prvateCode + "/add/" + userName + "/" + score);
        yield return request.SendWebRequest();
        Debug.Log(request.downloadHandler.text);
    }

    public static IEnumerator GetHighScore(UnityAction<List<UserData>> callBack)
    {
        UnityWebRequest request = UnityWebRequest.Get(url + publicCode + "/json");
        yield return request.SendWebRequest();

        var date = JsonMapper.ToObject(request.downloadHandler.text);
        var userDatas = date["dreamlo"]["leaderboard"]["entry"];
        List<UserData> userDataList = new List<UserData>();


        if (userDatas.IsArray)
        {

            foreach (JsonData user in userDatas)
            {
                userDataList.Add(new UserData(user["name"].ToString(), user["score"].ToString()));
            }
        }
        else
        {
            userDataList.Add(new UserData(userDatas["name"].ToString(), userDatas["score"].ToString()));
        }
        callBack(userDataList);

    }

}
