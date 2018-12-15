using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityOSC;

public class OSCController : MonoBehaviour {

    #region Network Settings
    public string TargetAddr;
    public int OutGoingPort;
    public int InComingPort;
    #endregion
    private Dictionary<string, ServerLog> servers;

    // Script initialization
    void Start(){
        OSCHandler.Instance.Init(TargetAddr, OutGoingPort, InComingPort);
        servers = new Dictionary<string, ServerLog>();
    }


    // NOTE: The received messages at each server are updated here
    // Hence, this update depends on your application architecture
    // How many frames per second or Update() calls per frame?
    void Update(){
        // must be called before you try to read value from osc server
        OSCHandler.Instance.UpdateLogs();

        // TODO
        // to ぱか太郎

        // データ受信部 (iPhone or Android -> Unity)
        servers = OSCHandler.Instance.Servers;
        foreach (KeyValuePair<string, ServerLog> item in servers)
        {
            // If we have received at least one packet,
            // show the last received from the log in the Debug console

            if (item.Value.log.Count > 0)
            {
                int lastPacketIndex = item.Value.packets.Count - 1;

                UnityEngine.Debug.Log(String.Format("SERVER: {0} ADDRESS: {1} VALUE 0: {2}",
                item.Key, // Server name
                item.Value.packets[lastPacketIndex].Address, // OSC address
                item.Value.packets[lastPacketIndex].Data[0].ToString())); //First data value
            }
        }

        // ここで受信部分の処理を記入する．


        // TODO
        // to パカ太郎
        // float変更も大丈夫！

        // データ送信部 (Unity -> iPhone or Android)
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("SendMessage");
            var sampleVals = new List<float>() { 1.2f, 2.2f, 3.3f };
            OSCHandler.Instance.SendMessageToClient("Unity", "/hoge/a", sampleVals);
        }
    }
}
