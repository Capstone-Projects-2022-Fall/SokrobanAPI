using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Diagnostics;
using UnityEngine.Networking;
using System;

[Serializable]
public class UserLevel
{ 
    public int level;
public string username;
public string score;
public string time;

}
[Serializable]
public class RootObject
{
    public UserLevel[] usersLevel;
}


public class LeaderBoard : MonoBehaviour
{
    public Transform recordContainer;
    public Transform recordTemplate;
    public TextMeshProUGUI userDetails;


    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator FetchData() // Method for getting things from API
    {

        UnityEngine.Debug.Log("Called");
        string uri = "https://sokroban.azurewebsites.net/Sokroban/LevelData?usr=FatherRabi";
        //This is where the API url is 

        using (UnityWebRequest request = UnityWebRequest.Get(uri))
        {
            yield return request.SendWebRequest();

            var data = request.downloadHandler.text;
            RootObject dataJson = JsonUtility.FromJson<RootObject>("{\"usersLevel\":"+data+"}");

            UnityEngine.Debug.Log(dataJson.usersLevel[0].username);
            var res = dataJson.usersLevel[0].level.ToString() + " | " + dataJson.usersLevel[0].username + " | " + dataJson.usersLevel[0].score + " | " + dataJson.usersLevel[0].time;

            userDetails.text = res;  //Find("User Details")?.GetComponent<TextMeshPro>().SetText(res);

        }
    }



    void Start() {
        // recordContainer = transform.Find("score_container");
        //recordTemplate = recordContainer.Find("score_template");

        
        StartCoroutine(FetchData());
        recordTemplate.gameObject.SetActive(false);

//        startTransform.Find("user")?.GetComponent<TextMeshPro>().SetText("AAA");


        float templateHeight = 35f;

        for(int i=0; i<10; i++)
        {
            Transform startTransform = Instantiate(recordTemplate, recordContainer);
            RectTransform startRectTransform = startTransform.GetComponent<RectTransform>();
            startRectTransform.anchoredPosition = new Vector2(0, -templateHeight * i);
            startTransform.gameObject.SetActive(true);

            int rank = i + 1;
            string rankString;

            switch (rank)
            {
                default:
                    rankString = rank + "TH"; break;

                case 1:
                    rankString = "1ST"; break;
                case 2:
                    rankString = "2ND"; break;

                case 3:
                    rankString = "3RD"; break;
                case 4:
                    rankString = "4TH"; break;




            }


            startTransform.Find("pos")?.GetComponent<TextMeshPro>().SetText(rankString);

            int score = 100 - i * 10;
            startTransform.Find("user")?.GetComponent<TextMeshPro>().SetText("AAA");

            startTransform.Find("score")?.GetComponent<TextMeshPro>().SetText(score.ToString());

            int levelsReached = i + 1;
            startTransform.Find("levels_reached")?.GetComponent<TextMeshPro>().SetText(levelsReached.ToString());

        }

    }

}
