using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quiz : MonoBehaviour
{
    [Header("Colours")]
    public Color normalColour;
    public Color selectedColour;

    [Header("Question 1 buttons")]
    public Button button1A;
    public Button button1B;

    [Header("Question 2 buttons")]
    public Button button2A;
    public Button button2B;

    [Header("Question 3 buttons")]
    public Button button3A;
    public Button button3B;

    [Header("Question 4 buttons")]
    public Button button4A;
    public Button button4B;
    public Button button4C;

    [Header("Music files")]
    public GameObject AudioA;
    public GameObject AudioB;
    public GameObject AudioC;

    [Header("Posible results")]
    public GameObject Quiz_Result;
    public GameObject ErrorScreen;
    public GameObject Result01;
    public GameObject Result02;
    public GameObject Result03;
    public GameObject Result04;
    public GameObject Result05;
    public GameObject Result06;
    public GameObject Result07;
    public GameObject Result08;

    private char? _question1, _question2, _question3, _music;

    private Dictionary<char, Button> question1Buttons;
    private Dictionary<char, Button> question2Buttons;
    private Dictionary<char, Button> question3Buttons;
    private Dictionary<char, Button> question4Buttons;

    float CurrentTime = 0f;
    float StartingTime = 5f;

    public void Start()
    {
        question1Buttons = new Dictionary<char, Button>();
        question1Buttons.Add('A', button1A);
        question1Buttons.Add('B', button1B);

        question2Buttons = new Dictionary<char, Button>();
        question2Buttons.Add('A', button2A);
        question2Buttons.Add('B', button2B);

        question3Buttons = new Dictionary<char, Button>();
        question3Buttons.Add('A', button3A);
        question3Buttons.Add('B', button3B);

        question4Buttons = new Dictionary<char, Button>();
        question4Buttons.Add('A', button4A);
        question4Buttons.Add('B', button4B);
        question4Buttons.Add('C', button4C);

        CurrentTime = StartingTime;
    }

    public void ButtonInput(string unparsedInput)
    {
        string[] input = unparsedInput.Split('-');

        Dictionary<char, Button> buttons = null;

        switch (input[0])
        {
            case "Q1":
                _question1 = input[1][0];
                buttons = question1Buttons;
                break;

            case "Q2":
                _question2 = input[1][0];
                buttons = question2Buttons;
                break;

            case "Q3":
                _question3 = input[1][0];
                buttons = question3Buttons;
                break;

            case "M":
                _music = input[1][0];
                buttons = question4Buttons;
                break;
        }

        // keeping the buttons selected
        if (buttons == null) return;

        foreach (var item in buttons)
        {
            var colors = item.Value.colors;

            if (item.Key == input[1][0]) colors.normalColor = selectedColour;
            else colors.normalColor = normalColour;

            item.Value.colors = colors;
        }
    }

    public void Result()
    {
        if (!_question1.HasValue || !_question2.HasValue || !_question3.HasValue || !_music.HasValue)
        {
            ErrorScreen.SetActive(true);
            StartCoroutine(WaitAndRemoveErrorScreen());
            return;
        }

        switch (_music)
        {
            case 'A':
                AudioA.SetActive(true);
                break;

            case 'B':
                AudioB.SetActive(true);
                break;

            case 'C':
                AudioC.SetActive(true);
                break;
        }


        string answer = new string(new char[] { _question1.Value, _question2.Value, _question3.Value });

        Quiz_Result.SetActive(true);

        switch (answer)
        {
            case "AAA":
                Result01.SetActive(true);
                break;

            case "AAB":
                Result02.SetActive(true);
                break;

            case "ABA":
                Result03.SetActive(true);
                break;

            case "ABB":
                Result04.SetActive(true);
                break;

            case "BBB":
                Result05.SetActive(true);
                break;

            case "BBA":
                Result06.SetActive(true);
                break;

            case "BAB":
                Result07.SetActive(true);
                break;

            case "BAA":
                Result08.SetActive(true);
                break;
        }
    }

    private IEnumerator WaitAndRemoveErrorScreen()
    {
        // wait a few seconds
        yield return new WaitForSeconds(2);
        ErrorScreen.SetActive(false);
    }
}