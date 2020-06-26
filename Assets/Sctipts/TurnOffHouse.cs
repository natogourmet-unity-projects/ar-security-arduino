using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffHouse : MonoBehaviour
{
    public char house;

    private void OnMouseDown()
    {
        ArduinoController.instance.TurnOffHouse(house);
    }
}
