using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ServerManager : MonoBehaviourPunCallbacks
{
    public TMP_InputField m_InputField;
    public TMP_Text m_textConnectLog;
    public TMP_Text m_textPlayerList;
    public Button connectButton;
    void Start()
    {

        m_textConnectLog.text = "���ӷα�\n";
        connectButton.onClick.AddListener(() => Connect());
    }

    public override void OnConnectedToMaster()
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 5;

        PhotonNetwork.LocalPlayer.NickName = m_InputField.text;
        PhotonNetwork.JoinOrCreateRoom("Room1", options, null);

    }
    public override void OnJoinedRoom()
    {
        updatePlayer();
        m_textConnectLog.text += m_InputField.text;
        m_textConnectLog.text += " ���� �濡 �����Ͽ����ϴ�.\n";
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        updatePlayer();
        m_textConnectLog.text += newPlayer.NickName;
        m_textConnectLog.text += " ���� �����Ͽ����ϴ�.\n";
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        updatePlayer();
        m_textConnectLog.text += otherPlayer.NickName;
        m_textConnectLog.text += " ���� �����Ͽ����ϴ�.\n";
    }

    public void Connect()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    void updatePlayer()
    {
        m_textPlayerList.text = "������";
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            m_textPlayerList.text += "\n";
            m_textPlayerList.text += PhotonNetwork.PlayerList[i].NickName;
        }
    }

}
