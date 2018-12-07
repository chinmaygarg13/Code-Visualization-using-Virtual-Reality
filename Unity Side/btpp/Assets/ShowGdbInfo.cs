using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ShowGdbInfo : MonoBehaviour
{
    public Text presentfunction;
    public ScrollRect sr;
    public ScrollRect hr;
    public Slider TimeRepeat;
    public Text txts;
    public Text play;

    Text code;
    string Total_code;
    string[] lines;
    static int index = 3;
    float prev_value = 2f;
    string func_name = "main";

    private int frame = 0;
    private Dictionary<string, int> base_index = new Dictionary<string, int>();
    private Dictionary<string, string> dict = new Dictionary<string, string>();

    // Use this for initialization
    void Start()
    {
        code = GetComponent<Text>();
        code.text = "";
        txts.text = "Welcome";
        LoadAllFunctions();
        baseindices();
        Load();
        lines = Total_code.Split('\n');
        InvokeRepeating("Code_update", 2f, TimeRepeat.value);
    }

    // Update is called once per frame
    void Update()
    {
        ++frame;
        frame = frame % 200;
        //Debug.Log (TimeRepeat.value);
        if (frame == 0 && TimeRepeat.value != prev_value)
        {
            //InvokeRepeating ("Code_update", TimeRepeat.value, TimeRepeat.value);
            prev_value = TimeRepeat.value;
        }
        Load();
    }

    public void onDragEnd()
    {
        Debug.Log("Drag End");
        CancelInvoke("Code_update");
        if (play.text == "Pause")
            InvokeRepeating("Code_update", 0.0f, TimeRepeat.value);
    }

    void Code_update()
    {

        Debug.Log(TimeRepeat.value);

        if (index >= lines.Length)
        {
            return;
        }
        else if (lines[index].Length >= 2 && lines[index][0] == '_' && lines[index][1] == '_')
        {
            return;
        }
        else if (lines[index].Length == 0)
        {
            ++index;
            return;
        }
        if (!char.IsDigit(lines[index][0]))
        {
            for (int i = 0; i < lines[index].Length; ++i)
            {
                // If the current line is an insrtuction to goto a function
                if (lines[index][i] == '(')
                {

                    // Determing the name of function
                    string function_code = "";
                    --i;
                    if (i >= 0 && lines[index][i] == ' ')
                        --i;
                    if (i == -1)
                        break;
                    while (i >= 0 && lines[index][i] != ' ')
                    {
                        function_code += lines[index][i];
                        --i;
                    }

                    // Assigning the name of function
                    char[] charArray = function_code.ToCharArray();
                    System.Array.Reverse(charArray);
                    function_code = new string(charArray);                  // Storing name of funciton in "function_code" variable
                    func_name = function_code;


                    // Showing function code in Code window
                    presentfunction.text = dict[function_code.Trim()];

                    // Displaying information
                    code.text += "\n====================================\n\n";
                    code.text += "Going in Function " + function_code + "\n";
                    Debug.Log("'" + function_code + "'");
                    code.text += "====================================\n\n";

                    // Correcting the scroll value
                    sr.verticalNormalizedPosition = 0f;
                    hr.horizontalNormalizedPosition = 0f;

                    // Go to next line
                    ++index;

                    return;
                }
            }
            code.text += lines[index];
            // Go to next line
            ++index;
        }
        else
        {

            // Determining the line nuber where to show arrow
            int line_no = 0;
            for (int i = 0; i < lines[index].Length && char.IsDigit(lines[index][i]); ++i)
            {
                line_no = line_no * 10 + lines[index][i] - '0';
            }

            // Showing arrow in function "func_name"
            int base_value = base_index[func_name];
            Debug.Log("Present line = " + line_no + " " + base_value);
            line_no -= base_value;
            string[] present_lines = dict[func_name.Trim()].Split('\n');
            present_lines[line_no] = "==> " + present_lines[line_no];
            presentfunction.text = "";
            for (int k = 0; k < present_lines.Length; ++k)
            {
                presentfunction.text += present_lines[k] + "\n";
            }

            // Going to next line
            ++index;

            // Showing all info that is obtained after the execution of this line
            while (index < lines.Length && lines[index].Length > 0 && !char.IsDigit(lines[index][0]))
            {
                foreach (char c in lines[index])
                {
                    if (c == '(')
                    {
                        return;
                    }
                }
                code.text += lines[index] + "\n";
                sr.verticalNormalizedPosition = 0f;
                hr.horizontalNormalizedPosition = 0f;
                ++index;
            }


        }
        code.text += "====================================\n\n";
        sr.verticalNormalizedPosition = 0f;
        hr.horizontalNormalizedPosition = 0f;
        return;
    }

    void Load()
    {
        string path = "Assets/gdb.txt";
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        Total_code = reader.ReadToEnd().ToString();
        //Debug.Log(reader.ReadToEnd());
        reader.Close();
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

    void baseindices()
    {
        string path = "Assets/code.txt";
        StreamReader reader = new StreamReader(path);
        string[] L = reader.ReadToEnd().ToString().Split('\n');
        int idx = 0;
        Debug.Log(L.Length);

        int curly = 0;

        while (idx < L.Length)
        {
            for (int i = 0; i < L[idx].Length; ++i)
            {
                if (L[idx][i] == '(' && curly == 0)
                {
                    string name = "";
                    int j = i;
                    while (i >= 0 && !char.IsLetter(L[idx][i]))
                        i--;
                    while (i >= 0 && char.IsLetter(L[idx][i]))
                    {
                        name = L[idx][i] + name;
                        --i;
                    }
                    base_index.Add(name.Trim(), idx + 1);
                    Debug.Log("Added " + name.Trim() + " " + idx);
                    i = j;
                }
                else if (L[idx][i] == '{')
                {
                    curly++;
                }
                else if (L[idx][i] == '}')
                {
                    curly--;
                }
            }
            ++idx;
        }
    }

    public void onPause()
    {
        if (play.text == "Play")
        {
            InvokeRepeating("Code_update", 2f, TimeRepeat.value);
            play.text = "Pause";
        }
        else
        {
            CancelInvoke();
            play.text = "Play";
        }
    }

    public void GoBack()
    {
        CancelInvoke();
        index = 0;
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        SceneManager.LoadScene("Menu", LoadSceneMode.Single);
    }
}