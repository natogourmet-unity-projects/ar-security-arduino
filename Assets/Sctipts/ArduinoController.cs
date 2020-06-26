using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoController : MonoBehaviour
{
    public static ArduinoController instance;
    SerialPort serial;
    public bool A = false, B = false, C = false;
    public GameObject ALight, BLight, CLight;
    public int port;

    void Start()
    {
        instance = this;

        serial = new SerialPort("COM" + port, 9600);
        serial.Open();
        serial.ReadTimeout = 10;
    }
    
    void Update()
    {
        char c = (char)serial.ReadChar();
        Debug.Log(c);
        if (serial.IsOpen)
        {
            if (!A && c == 'A')
            {
                ALight.SetActive(true);
                A = true;
            }
            if (!B && c == 'B')
            {
                BLight.SetActive(true);
                B = true;
            }
            if (!C && c == 'C')
            {
                CLight.SetActive(true);
                C = true;
            }
        }
    }

    public void TurnOffHouse(char house)
    {
        switch (house)
        {
            case 'A':
                ALight.SetActive(false);
                A = false;
                break;
            case 'B':
                BLight.SetActive(false);
                B = false;
                break;
            case 'C':
                CLight.SetActive(false);
                C = false;
                break;
            default:
                break;
        }
    }
    
    public void SetLED(bool setter)
    {
        if (serial.IsOpen)
        {
            if (setter)
            {
                serial.Write("A");
            }
            else
            {
                serial.Write("O");
            }
        }
    }
}
