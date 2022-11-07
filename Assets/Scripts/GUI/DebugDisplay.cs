using System.Collections.Generic;
using TMPro;
using UnityEngine;
public class DebugDisplay : MonoBehaviour
{
    private Dictionary<string, string> debugLog = new();
    public TextMeshProUGUI display;

    private void OnEnable()
    {
        Application.logMessageReceived += HandleLog;
    }


    private void OnDisable()
    {
        Application.logMessageReceived -= HandleLog;
    }

    private void HandleLog(string condition, string stacktrace, LogType type)
    {
        if (type == LogType.Log)
        {
            string[] splitString = condition.Split(char.Parse(":"));
            string debugKey = splitString[0];
            string debugValue = splitString.Length > 1 ? splitString[1] : "";

            if (debugLog.ContainsKey(debugKey)) debugLog[debugKey] = debugValue;
            else debugLog.Add(debugKey, debugValue);
        }

        string displayTxt = "";
        foreach (KeyValuePair<string, string> log in debugLog)
        {
            if (log.Value == "") displayTxt += log.Key + "\n";
            else displayTxt += log.Key + ": " + log.Value + "\n";

            display.text = displayTxt;
        }
    }
}