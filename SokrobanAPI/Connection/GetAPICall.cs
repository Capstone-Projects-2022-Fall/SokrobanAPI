using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using TMPro;
using System;
using UnityEngine.Networking;

public class GetAPICall : MonoBehaviour
{
    public class Fact
    {
        public string fact { get; set; }
        public int length { get; set; }
    }

    public TMP_Text factText; 

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(GetRequest("https://catfact.ninja/fact"));
    }
    IEnumerator GetRequest(String URL)
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(URL))
        {
            yield return webRequest.SendWebRequest();

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.Success:

                    Fact fact = JsonConvert.DeserializeObject<Fact>(webRequest.downloadHandler.text);
                    factText.text = fact.fact;
                    break;
            }
        }
    }
    public void newFact()
    {
        StartCoroutine(GetRequest("https://catfact.ninja/fact"));
    }
}
