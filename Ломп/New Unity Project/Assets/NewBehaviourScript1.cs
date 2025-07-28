using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using UnityEngine;

public class NewBehaviourScript1 : MonoBehaviour
{
    public string xml_tecst = @"";

    public 
    void Start()
    {
        string filepath = Application.dataPath + @"/поиск.xml";
        XElement t = XElement.Load(filepath);
        var records =  t.Elements();
        int r = records.Count();
        var f1 = records.Select(w => new {id = w.Attribute("id").Value,names = w.Element("field").Value }).ToArray();
        foreach(var e in f1)
        {
            Debug.Log(e.id);
            Debug.Log(e.names);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
