using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;  // WebSocketSharp ���ӽ����̽� ���

public class ServerConnection : MonoBehaviour
{
    private WebSocket webSocket;  // WebSocketSharp�� WebSocket ���

    public void ConnectToServer(string url)
    {
        webSocket = new WebSocket(url);

        webSocket.OnMessage += (sender, e) =>
        {
            Debug.Log("Received from server: " + e.Data);
        };

        webSocket.Connect();
        Debug.Log("Connected to " + url);
    }

    void OnDestroy()
    {
        if (webSocket != null)
        {
            webSocket.Close();
            webSocket = null;
        }
    }
}
