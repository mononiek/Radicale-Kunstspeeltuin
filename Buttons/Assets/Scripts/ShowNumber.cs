using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ShowNumber : MonoBehaviour
{
    public Text txt_ShowNumber;

    public void EnterNumber(int _Number)
    {
        txt_ShowNumber.text = _Number.ToString();
    }
}
