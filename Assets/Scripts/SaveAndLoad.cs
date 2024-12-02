using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UI;
using UnityEngine.XR;

public class SaveAndLoad : MonoBehaviour
{
    public string st;
    public List<int> list;
    private string localPath;
    public class MyList
    {
        public List<int> list;
       
    }
   
    public void Save() 
    {

        var listInClass = new MyList();
        listInClass.list = list;
        var outputString = JsonUtility.ToJson(listInClass);
        st = outputString;
    }


















    public void Load() 
    {
        if (PlayerPrefs.HasKey("Predmets"))
        {
            string globalDataJSON = PlayerPrefs.GetString("Predmets");
            MyList loadedList = JsonUtility.FromJson<MyList>(globalDataJSON);
            for (int i = 0; i < loadedList.list.Count; i++)
            {
               list.Add(loadedList.list[i]);
            }
        }
    }
}
