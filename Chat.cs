using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chat : MonoBehaviour
{
    const int PORT = 7777;
    public int temp;
    public int on;
    public int air;
    public int tempOven;
    public int oven;
    public int light1;
    public int light2;
    public int light3;
    public int tea;
    Client client;
    public static List<string> message = new List<string>();
    string outMessage = "";
    void Start()
    {
        Application.runInBackground = true;
        client = new Client(PORT, "192.168.0.21");
        client.begin();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnGUI()
    {
        //outMessage = " aaaaaa";
        //outMessage = GUILayout.TextArea(outMessage, GUILayout.Width(250), GUILayout.Height(50));
        // if (GUI.Button(new Rect (100,25,25,25), "Send")) client.sendMsg(outMessage);
        
        GUI.BeginScrollView(new Rect(15, 400, 250, 100), new Vector2(0, 0), new Rect(0, 0, 200, 100));
        foreach (string mes in message)
        {
            if (GameObject.Find("OutMessage"))
                GameObject.Find("OutMessage").GetComponent<outMessage>().outMes(mes);
            if (GameObject.Find("OutMessage (1)"))
                GameObject.Find("OutMessage (1)").GetComponent<outMessage>().outMes(mes);
            if (GameObject.Find("OutMessage (2)"))
                GameObject.Find("OutMessage (2)").GetComponent<outMessage>().outMes(mes);
            //GUILayout.Label(mes);
        }
        GUI.EndScrollView();
    }

    public void messaAir()
    {
        string message;
        //temp = countTemperature.Instance.temp;
        temp = GameObject.Find("count").GetComponent<countTemperature>().getTemp();
        on = GameObject.Find("ButtonScr").GetComponent<buttonColor>().on;
        air = GameObject.Find("ButtonScr").GetComponent<buttonColor>().air;
        message ="0 " + on.ToString() + " " + temp.ToString() + " " + air.ToString();
        client.sendMsg(message);
    }

    public void messaOven()
    {
        string message;
        tempOven = GameObject.Find("count (1)").GetComponent<countTemperature>().tempOven;
        on = GameObject.Find("ButtonScr (1)").GetComponent<buttonColor>().on;
        oven = GameObject.Find("ButtonScr (1)").GetComponent<buttonColor>().oven;
        message = "1 " + on.ToString() + " " + tempOven.ToString() + " " + oven.ToString();
        client.sendMsg(message);
    }

    public void messaLights()
    {
        string message;
        light1 = GameObject.Find("ButtonScr (lights)").GetComponent<buttonColor>().light1;
        light2 = GameObject.Find("ButtonScr (lights)").GetComponent<buttonColor>().light2;
        light3 = GameObject.Find("ButtonScr (lights)").GetComponent<buttonColor>().light3;
        message = "2 " + light1.ToString() + " " + light2.ToString() + " " + light3.ToString();
        client.sendMsg(message);

    }

    public void messaTeapot()
    {
        string message;
        tea = GameObject.Find("ButtonScr (tea)").GetComponent<buttonColor>().tea;
        message = "3 " + tea.ToString();
        client.sendMsg(message);
    }
}
