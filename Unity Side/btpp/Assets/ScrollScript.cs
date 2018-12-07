using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class ScrollScript : MonoBehaviour
{

    public ScrollRect scrollView;
    public GameObject scrollContent;
    public GameObject scrollItemPrefab;

    private SortedDictionary<string, string> dict = new SortedDictionary<string, string>();
    //string[] name = new string[] { };

    // Use this for initialization
    void Start()
    {
        LoadAllFunctions();
        foreach (KeyValuePair<string, string> kv in dict)
        {
            generateItem(kv.Key);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void LoadAllFunctions()
    {
        string path = "Assets/fun_list.txt";
        StreamReader reader = new StreamReader(path);
        string[] L = reader.ReadToEnd().ToString().Split('\n');
        int idx = 0;
        Debug.Log(L.Length);
        while (idx < L.Length)
        {
            string name = L[idx].Substring(18);
            Debug.Log(name);
            string content = "";
            ++idx;
            while (idx < L.Length)
            {
                if (idx == L.Length - 1 || (L[idx].Length >= 18 && L[idx].Substring(0, 8) == "Function"))
                {
                    if (idx == L.Length - 1)
                    {
                        content += L[idx];
                        ++idx;
                    }
                    name = name.Trim();
                    dict.Add(name, content);
                    Debug.Log(dict[name] + "\n" + "'" + name + "'");
                    if (name == "func")
                        Debug.Log("YO '" + name + "'" + " => " + content + " " + dict[name]);
                    break;
                }
                content += L[idx] + "\n";
                ++idx;
            }
        }
        //Debug.Log (dict ["main"]);
        Debug.Log("GOT OUT");
        return;
    }

    void generateItem(string itemNumber)
    {
        GameObject scrollItemObj = Instantiate(scrollItemPrefab);
        scrollItemObj.transform.SetParent(scrollContent.transform, false);
        scrollItemObj.transform.Find("num").gameObject.GetComponent<Text>().text = itemNumber;
    }

    public void onbutton()
    {

    }
}
