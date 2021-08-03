using PlayFab.ClientModels;
using UnityEngine;
using PlayFab;
using System.Collections.Generic;
using System;
using TMPro;
using UnityEngine.UI;

public class PlayFabManager : MonoBehaviour
{
    [SerializeField]
    GameObject tableRaw;

    [SerializeField]
    Transform leaderBoardTable;
    // Start is called before the first frame update
    void Start()
    {
        Login();
       
    }

    void Login() 
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result) 
    {
        GetLeaderBoard();
        Debug.Log("Succesful login/account create!");
    }

    void OnError(PlayFabError error) 
    {
        Debug.Log("Error while logging in/ creating account");
        Debug.Log(error.GenerateErrorReport());

    }

    public void SendLeaderBoard(int score) 
    {
        var request = new UpdatePlayerStatisticsRequest 
        {
            Statistics = new List<StatisticUpdate> 
            {
                new StatisticUpdate
                {
                    StatisticName = "PlatformScore",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderBoardUpdate, OnError);
    }

    private void OnLeaderBoardUpdate(UpdatePlayerStatisticsResult result)
    {
        Debug.Log("Seccessful leaderboard sent!");
    }

    public void GetLeaderBoard() 
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlatformerScore",
            StartPosition = 0,
            MaxResultsCount = 10
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderBoardGet, OnError);
    }

    private void OnLeaderBoardGet(GetLeaderboardResult result)
    {

        foreach (var iteam in result.Leaderboard) 
        {
            Debug.Log(string.Format("PLACE:{0}|ID:{1}|VALUE:{2}", iteam.Position, iteam.PlayFabId, iteam.StatValue));

            GameObject tableLine = Instantiate(tableRaw, leaderBoardTable);
            Text[] texts = tableLine.GetComponentsInChildren<Text>();
            texts[0].text = iteam.Position.ToString();
            texts[1].text = iteam.PlayFabId;
            texts[2].text = iteam.StatValue.ToString();


        }
    }
}
 