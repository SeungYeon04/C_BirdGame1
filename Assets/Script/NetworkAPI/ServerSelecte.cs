using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using Newtonsoft.Json.Linq;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ServerSelector : MonoBehaviour
{
    private string accessKey = "acb242b4e29bc5";  // API ���� Ű
    private string apiUrl;  // API URL

    public Text statusText;
    public GameObject buttonPrefab; // ��ư ������
    public Transform buttonParent; // ��ư���� ��ġ�� �θ� ��ü

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
            case "KR": return new List<string> { "��Ƽä��1", "��Ƽä��2", "��Ƽä��3", "�̱�ä��1" };
            case "US": return new List<string> { "MultiChannel1", "MultiChannel2", "MultiChannel3", "SingleChannel1" };
            default: return new List<string> { "MultiChannel1", "MultiChannel2", "MultiChannel3", "SingleChannel1" };
        }
    }

    private void ConnectToChannel(string channel)
    {
        Debug.Log($"Attempting to connect to channel: {channel}...");
        // ���� ������ �����ϴ� ������ �߰��ϼ���.
    }

    private void SetLanguage(string countryCode)
    {
        statusText.text = countryCode == "KR" ? "������ ���� ��..." : "Connecting to server...";
    }
}
