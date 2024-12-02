using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using YG.Example;
using YG;
public class Lives : MonoBehaviour
{
    public int helse = 5;
    public int balls;
    public Data data;
    public GameObject[] lives;
    public static Lives regit { get; set; }

    void Awake()
    {
        if (regit == null) 
        {
            regit = this;
        }
    }
    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Reclam;
    }
    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Reclam;
    }
    void Reclam(int id) 
    {
        if (id > 0) 
        {
            helse = 5;
            Interface.rid.Sum(1);
        }
    }
    public void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);

    }
        public void BalsTimer() 
    {
        if (balls > 1)
        {
            balls -= 1;
        }
        else 
        {
            Interface.rid.Sum(3);
        }
    }
    private void OnDestroy()
    {
        Destroy(regit);
    }
    public void Damag() 
    {
        if (helse > 0)
        {
           helse -= 1;
        }
        else 
        {
            Interface.rid.Sum(2);
        }
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < lives.Length; i++) 
        {
            if (i <= helse)
            {
                lives[i].SetActive(true);
            }
            else 
            {
                lives[i].SetActive(false);
            }
        }
    }
}
