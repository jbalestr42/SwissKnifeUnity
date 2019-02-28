using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace SKU
{
    /// <summary>
    /// Log class called from everywhere inside the code
    /// </summary>
    public static class Log
    {
        /// <summary>
        /// Available log type to manage the logs file and the display
        /// </summary>
        public enum LogType
        {
            NoChoice = -1,
            Gameplay = 0,
            Network = 1,
            Warning = 2,
            Error = 3,
            Localization = 4,
            Editor = 5,
            UI = 6,
            StateMachine = 7,
            Log = 99
        }
        
        /// <summary>
        /// Log structure to save the logs through the runtime
        /// </summary>
        private class LogStruct
        {
            private List<string> _logs = new List<string>();

            public List<string> Logs
            {
                get { return _logs; }
            }

            public void AddMessage(string message)
            {
                _logs.Add(message);
            }
        }

        /// <summary>
        /// Flag to store or not the logs during the run time
        /// </summary>
        private static bool _saveLogsWhileRunTime = false;

        /// <summary>
        /// Flag used to know if the logs dictionary has been initialized
        /// </summary>
        public static bool _hasDictionaryBeenInitialized = false;

        private static string _gameplayColor = "green";
        private static string _networkColor = "blue";
        private static string _logClassInformationColor = "grey";
        private static string _localizationColor = "brown";
        private static string _editorColor = "orange";
        private static string _uiColor = "black";
        private static string _stateMachineColor = "purple";

        private static string _standardPath;

        private static Dictionary<LogType, LogStruct> _logs = new Dictionary<LogType, LogStruct>();
        
        public static bool SaveLogsWhileRunTime {
            get { return _saveLogsWhileRunTime; }
            set { if (value) Init(); _saveLogsWhileRunTime = value;  }
        }

        private static void Init()
        {
            if (_hasDictionaryBeenInitialized)
                return;

            _standardPath = Application.persistentDataPath + "/Logs";

            if (!Directory.Exists(_standardPath))
            {
                Directory.CreateDirectory(_standardPath);
            }

            _logs.Add(LogType.Gameplay, new LogStruct());
            _logs.Add(LogType.Network, new LogStruct());
            _logs.Add(LogType.Warning, new LogStruct());
            _logs.Add(LogType.Error, new LogStruct());
            _logs.Add(LogType.Log, new LogStruct());
            _logs.Add(LogType.Localization, new LogStruct());
            _logs.Add(LogType.Editor, new LogStruct());
            _logs.Add(LogType.UI, new LogStruct());
            _logs.Add(LogType.StateMachine, new LogStruct());
            _hasDictionaryBeenInitialized = true;
        }

        public static void Info(string message, GameObject gO = null)
        {
            Init();
            AddToLogString(message, LogType.Log);
            Debug.Log(string.Format("<color={0}>{1}</color>", _logClassInformationColor, message));
        }

        public static void Gameplay(string message, GameObject gO = null)
        {
            Init();
            AddToLogString(message, LogType.Gameplay);
            Debug.Log(string.Format("<color={0}>{1}</color>", _gameplayColor, message));
        }

        public static void WarningLocalization(string message, GameObject gO = null)
        {
            Init();
            AddToLogString(message, LogType.Localization);
            Debug.LogWarning(string.Format("<color={0}>{1}</color>", _localizationColor, message));
        }

        public static void Network(string message, GameObject gO = null)
        {
            Init();
            AddToLogString(message, LogType.Network);
            Debug.Log(string.Format("<color={0}>{1}</color>", _networkColor, message));
        }

        public static void Editor(string message, GameObject gO = null)
        {
            Init();
            AddToLogString(message, LogType.Editor);
            Debug.Log(string.Format("<color={0}>{1}</color>", _editorColor, message));
        }

        public static void UI(string message, GameObject gO = null)
        {
            Init();
            AddToLogString(message, LogType.UI);
            Debug.Log(string.Format("<color={0}>{1}</color>", _uiColor, message));
        }

        public static void StateMachine(string message, GameObject go = null)
        {
            Init();
            AddToLogString(message, LogType.StateMachine);
            Debug.Log(string.Format("<color={0}>{1}</color>", _stateMachineColor, message));
        }

        public static void Warning(string message, GameObject gO = null)
        {
            Init();
            AddToLogString(message, LogType.Warning);
            Debug.LogWarning(message, gO);
        }

        public static void Error(string message, GameObject gO = null)
        {
            Init();
            AddToLogString(message, LogType.Error);
            Debug.LogError(message, gO);
        }

        private static void AddToLogString(string message, LogType logType)
        {
            if (!SaveLogsWhileRunTime)
                return;

            LogStruct currentLog;
            _logs.TryGetValue(logType, out currentLog);

            TimeSpan timeSpan = DateTime.Now.TimeOfDay;

            string hours = "";
            if (timeSpan.TotalHours < 10)
            {
                hours = "0";
            }
            hours += (int)Math.Floor(timeSpan.TotalHours);

            string minutes = "";
            if (timeSpan.TotalMinutes % 60 < 10)
            {
                minutes = "0";
            }
            minutes += (int)(Math.Floor(timeSpan.TotalMinutes) % 60);

            string seconds = "";
            if (timeSpan.TotalSeconds % 60 < 10)
            {
                seconds = "0";
            }
            seconds += (int)(Math.Floor(timeSpan.TotalSeconds) % 60);

            currentLog.AddMessage(string.Format("{0}h {1}min {2}sec || {3}",
                hours, minutes, seconds, message));
        }

        public static void SaveLogs(LogType logType = LogType.NoChoice)
        {
            if (logType == LogType.NoChoice)
            {
                SaveLog(LogType.Gameplay);
                SaveLog(LogType.Network);
                SaveLog(LogType.Localization);
                SaveLog(LogType.Editor);
                SaveLog(LogType.UI);
                SaveLog(LogType.Warning);
                SaveLog(LogType.Error);
                SaveLog(LogType.Log);
            } else
            {
                SaveLog(logType);
            }
        }

        private static void SaveLog(LogType logType)
        {
            string path = string.Format("{0}/{1}_{2}.log", _standardPath, DateTime.Now.ToString("MM_dd_HH_mm_ss"), logType.ToString());
            StreamWriter sr = File.CreateText(path);
            LogStruct log;

            _logs.TryGetValue(logType, out log);

            foreach (string logLine in log.Logs)
            {
                sr.WriteLine(logLine);
            }

            sr.Close();

            Log.Info(string.Format("Logs saved at this address: {0}", path));
        }
    }
}