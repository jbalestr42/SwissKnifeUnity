using UnityEngine;

public static class Log {

	public static void Display(string log, GameObject gO = null)
    {
        Debug.Log(log, gO);
    }

    public static void Warning(string log, GameObject gO = null)
    {
        Debug.LogWarning(log, gO);
    }

    public static void Error(string log, GameObject gO = null)
    {
        Debug.LogError(log, gO);
    }
}
