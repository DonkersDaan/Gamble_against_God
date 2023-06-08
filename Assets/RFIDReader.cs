using System;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class RFIDReader : MonoBehaviour
{
    //This script is for making sense of the incomming serial data from the RFID-reader.
    [SerializeField] SerialPort serialPort;
    [SerializeField] GameObject[] listObjects; //A list of different GameObjects, each with their own Unique list
    [SerializeField] public List<string>[] codeLists;

    //If one is true, that game cannot be played a second time
    public bool game1Started = false;
    public bool game2Started = false;
    public bool game3Started = false;
    public bool game4Started = false;
    public bool game5Started = false;

    //If a card has been scanned and a minigame has started, one will turn true untill the minigame is finished
    public bool waitForMinigame1 = false;
    public bool waitForMinigame2 = false;
    public bool waitForMinigame3 = false;
    public bool waitForMinigame4 = false;
    public bool waitForMinigame5 = false;

    public GameObject LevelsStart;

    //Initialize serial port connection to Teensy board ASAP
    void Awake()
    {
        serialPort = new SerialPort("COM3", 9600); //COM4
        serialPort.Open();
    }

    void Start()
    {
        // Initialize the codeLists for each object
        codeLists = new List<string>[listObjects.Length];
        for (int i = 0; i < listObjects.Length; i++)
        {
            // Get the list component on the list object
            ListComponent listComponent = listObjects[i].GetComponent<ListComponent>();

            // Add the list of codes to the codeLists array
            codeLists[i] = listComponent.codes;

            // Debug statement to print the codes for each list
            //Debug.Log("Codes for list " + i + ": " + string.Join(", ", codeLists[i].ToArray()));
        }
    }

    void Update()
    {
        // Read incoming data from serial port
        if (serialPort.IsOpen && serialPort.BytesToRead > 0)
        {

            string serialData = serialPort.ReadLine(); //only first line
            Debug.Log("Received data: " + serialData);

            serialPort.DiscardOutBuffer(); //Everything in the buffer, after the first line, throw away (what it sends to Arduino)
            serialPort.DiscardInBuffer(); //Everything in the buffer, after the first line, throw away (what it recieves from Arduino)

            if (serialData.Contains("Reader 0") && !game1Started && !waitForMinigame1)
            {
                foreach (string id in codeLists[0])
                {
                    if (id == serialData)
                    {
                        Debug.Log("Matching code found on list " + serialData);
                        LevelsStart.GetComponent<CheckLevels>().Chapter1();
                        game1Started = true; //Don't go in this if-statement anymore.
                    }
                }
            }
            else if (serialData.Contains("Reader 1") && !game2Started && !waitForMinigame2)
            {
                foreach (string id in codeLists[1])
                {
                    if (id == serialData)
                    {
                        Debug.Log("Matching code found on list " + serialData);
                        LevelsStart.GetComponent<CheckLevels>().Chapter2();
                        game2Started = true; //Don't go in this if statement anymore.
                    }
                }
            }
            else if (serialData.Contains("Reader 2") && !game3Started && !waitForMinigame3)
            {
                foreach (string id in codeLists[2])
                {
                    if (id == serialData)
                    {
                        Debug.Log("Matching code found on list " + serialData);
                        LevelsStart.GetComponent<CheckLevels>().Chapter3();
                        game3Started = true; //Don't go in this if statement anymore.
                    }
                }
            }
            else if (serialData.Contains("Reader 3") && !game4Started && !waitForMinigame4)
            {
                foreach (string id in codeLists[3])
                {
                    if (id == serialData)
                    {
                        Debug.Log("Matching code found on list " + serialData);
                        LevelsStart.GetComponent<CheckLevels>().Chapter4();
                        game4Started = true; //Don't go in this if statement anymore.
                    }
                }
            }
            else if (serialData.Contains("Reader 4"))
            {

            }
            else
            {
                Debug.Log("No match found");
            }

        }
    }

    void OnApplicationQuit()
    {
        // Close serial port connection when application exits
        if (serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}