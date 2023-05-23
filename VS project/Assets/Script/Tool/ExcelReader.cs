using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class ExcelReader : MonoBehaviour
{
    public TextAsset textAssetdata;

    public TMP_InputField TextInput;
    private string Text;

    public TextMeshProUGUI Name;
    public TextMeshProUGUI Level;
    public TextMeshProUGUI Health;
    public TextMeshProUGUI Speed;

    void Start()
    {

    }

    void Update()
    {
        Text = TextInput.text;
    }

    public void Search()
    {
        string[] data = textAssetdata.text.Split(new string[] { ";", "/n" }, System.StringSplitOptions.None);

        for(int i = 0; i < data.Length; i++)
        {
            if (Text == data[i])
            {
                Level.text = data[i +1];
                Health.text = data[i +2];
                Speed.text = data[i +3];
            }
        }
    }
}
