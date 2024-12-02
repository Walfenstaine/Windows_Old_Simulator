using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Lusa : MonoBehaviour
{
    public Text scores;
    public Data data;

    public void OnClick() 
    {
        YandexGame.savesData.record += 1;
        YandexGame.SaveProgress();
        YandexGame.NewLeaderboardScores("LEADER666", YandexGame.savesData.record);
    }
    private void FixedUpdate()
    {
        scores.text = "" + YandexGame.savesData.record;
    }
}
