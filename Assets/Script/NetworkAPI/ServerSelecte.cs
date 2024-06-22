using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ServerSelector : MonoBehaviour
{
    private string accessKey = "acb242b4e29bc5";  // API 접근 키
    private string apiUrl;  // API URL

    public Text statusText;
    public GameObject buttonPrefab; // 버튼 프리팹
    public Transform buttonParent; // 버튼들이 배치될 부모 객체

    void Start()
    {
        apiUrl = $"https://ipinfo.io?token={accessKey}";
        StartCoroutine(GetCountryCode());
    }

    private IEnumerator GetCountryCode()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get(apiUrl))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.ConnectionError || webRequest.result == UnityWebRequest.Result.ProtocolError)
            {
                Debug.LogError("Failed to get country code: " + webRequest.error);
                statusText.text = "Failed to get country code.";
            }
            else
            {
                string jsonResponse = webRequest.downloadHandler.text;
                Debug.Log("API Response: " + jsonResponse);

                JObject json = JObject.Parse(jsonResponse);
                if (json["country"] == null)
                {
                    Debug.LogError("Country code not found in the response.");
                    statusText.text = "Country code not found.";
                }
                else
                {
                    string countryCode = json["country"].ToString();
                    SetupChannels(countryCode);
                }
            }
        }
    }

    private void SetupChannels(string countryCode)
    {
        List<string> channels = GetChannelsByCountry(countryCode);
        foreach (string channel in channels)
        {
            GameObject newButton = Instantiate(buttonPrefab, buttonParent);
            newButton.GetComponentInChildren<Text>().text = channel;
            newButton.GetComponent<Button>().onClick.AddListener(() => ConnectToChannel(channel));
        }

        SetLanguage(countryCode);
    }

    private List<string> GetChannelsByCountry(string countryCode)
    {
        switch (countryCode)
        {
            case "KR": return new List<string> { "멀티채널1", "멀티채널2", "멀티채널3", "싱글채널1" };
            case "US": return new List<string> { "MultiChannel1", "MultiChannel2", "MultiChannel3", "SingleChannel1" };
            default: return new List<string> { "MultiChannel1", "MultiChannel2", "MultiChannel3", "SingleChannel1" };
        }
    }

    private void ConnectToChannel(string channel)
    {
        Debug.Log($"Attempting to connect to channel: {channel}...");
        // 실제 서버에 연결하는 로직을 추가하세요.
    }

    private void SetLanguage(string countryCode)
    {
        statusText.text = countryCode == "KR" ? "서버에 연결 중..." : "Connecting to server...";
    }
}
