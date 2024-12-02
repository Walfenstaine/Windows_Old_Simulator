using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEngine.UI;

public class XML_REED : MonoBehaviour
{
    public Text text;
    public string logg, name, famely;
    public int age, fone;
    private string localPath;
    private void Start()
    {
        Create_XML();
    }
    private void Create_XML()
    {
        localPath = Application.streamingAssetsPath + "/" + logg + ".XML";
        if (!File.Exists(localPath))
        {
            XmlDocument xml = new XmlDocument();
            XmlDeclaration xmldecl = xml.CreateXmlDeclaration("1.0", "UTF-8", "");
            XmlElement root = xml.CreateElement("Data");
            XmlElement info = xml.CreateElement("Info");
            info.SetAttribute("Name", name);
            info.SetAttribute("Famely", famely);
            info.SetAttribute("Age", ""+age);
            info.SetAttribute("Phone", ""+fone);
            root.AppendChild(info);
            xml.AppendChild(root);
            xml.Save(localPath);
        }
    }

    public void AddXML()
    {
        localPath = Application.streamingAssetsPath + "/" + logg + ".XML";
        if (File.Exists(localPath))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(localPath);
            XmlNode root = xml.SelectSingleNode("Data");
            XmlElement info = xml.CreateElement("Info");
            info.SetAttribute("Name", name);
            info.SetAttribute("Famely", famely);
            info.SetAttribute("Age", "" + age);
            info.SetAttribute("Phone", "" + fone);
            root.AppendChild(info);
            xml.AppendChild(root);
            xml.Save(localPath);
            Debug.Log("Add XML success!");
        }
    }
    public void Readxml()
    {
        localPath = Application.streamingAssetsPath + "/" + logg + ".XML";
        if (File.Exists(localPath))
        {
            XmlDocument xml = new XmlDocument();
            xml.Load(localPath);
            XmlNodeList nodeList = xml.SelectSingleNode("Data").ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                if (xe.Name == "Info")
                {
                    text.text = (xe.GetAttribute("Name")) + " " + (xe.GetAttribute("Famely")) + " Возраст:" + (xe.GetAttribute("Age")) + " телефон:" + (xe.GetAttribute("Phone"));
                   // Debug.Log(xe.GetAttribute("Name"));
                   // Debug.Log(xe.GetAttribute("Age"));
                    //Debug.Log(xe.GetAttribute("Phone"));
                }
            }
        }
    }
    public void UpdateXml()
    {
        localPath = UnityEngine.Application.streamingAssetsPath + "/" + logg + ".XML";
        if (File.Exists(localPath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(localPath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("Data").ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                if (xe.GetAttribute("Name") == "Info")
                {
                    xe.SetAttribute("Age", "21");
                    break;
                }
            }
            xmlDoc.Save(localPath);
            Debug.Log("Update XML success!");
        }
    }
    public void DeleteXml()
    {
        localPath = UnityEngine.Application.streamingAssetsPath + "/" + logg + ".XML";
        if (File.Exists(localPath))
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(localPath);
            XmlNodeList nodeList = xmlDoc.SelectSingleNode("Data").ChildNodes;
            foreach (XmlElement xe in nodeList)
            {
                if (xe.GetAttribute("Name") == " ")
                {
                    xe.RemoveAttribute("Phone");
                }
                if (xe.GetAttribute("Name") == "   ")
                {
                    xe.RemoveAll();
                }
            }
            xmlDoc.Save(localPath);
            Debug.Log("Delete XML success!");
        }
    }
}
