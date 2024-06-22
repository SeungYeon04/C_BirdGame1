using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WebSocketSharp;  // WebSocketSharp 네임스페이스 사용

public class ServerConnection : MonoBehaviour
{
    private WebSocket webSocket;  // WebSocketSharp의 WebSocket 사용

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
