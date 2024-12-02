using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEngine;

public class Reeeeeeeed : MonoBehaviour
{
    public List<Vector3> pos;
    public string logg;

    [HideInInspector] public List<string> coordinates_A;
    [HideInInspector] public List<string> coordinates_B;
    [HideInInspector] public List<string> coordinates_C;
    [HideInInspector] public List<string> coordinates_D;
    [HideInInspector] public List<string> coordinates_E;
    [HideInInspector] public List<string> coordinates_F;
    [HideInInspector] public List<string> coordinates;

    public string localPath;

    private void Awake()
    {
        Readxml();
    }
    public void Readxml()
    {
        localPath = Application.streamingAssetsPath + "/" + logg + ".XML";
        if (File.Exists(localPath))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(localPath);
            XmlNodeList nodeList = xml.SelectNodes("Data/Placemark/Point/coordinates");
            foreach (XmlElement xe in nodeList)
            {
                if (xe.Name == "coordinates")
                {
                    for (int i = 0; i < xe.ChildNodes.Count; i++)
                    {
                        coordinates.Add(xe.ChildNodes[i].InnerText);
                    }
                }
            }
        }
        for (int i = 0; i < coordinates.Count; i++)
        {
            string[] a = coordinates[i].Split(',');
            coordinates_A.Add(a[0]);
            coordinates_B.Add(a[1]);
            string[] b = coordinates_A[i].Split('.');
            string[] c = coordinates_B[i].Split('.');
            coordinates_C.Add(b[0]);
            coordinates_D.Add(b[1]);
            coordinates_E.Add(c[0]);
            coordinates_F.Add(c[1]);

            float x_const = float.Parse(coordinates_D[i])/10;
            float y_const = float.Parse(coordinates_D[i]) / 10;

            String x = coordinates_C[i] + "," + Math.Floor(x_const)*10;
            String y = coordinates_E[i] + "," + Math.Floor(y_const)*10;
            //pos.Capacity = 700;
            float x_e = float.Parse(x);
            float y_e = float.Parse(y);
            pos.Insert(i, new Vector3(x_e, y_e, 0));
        }
    }
}
