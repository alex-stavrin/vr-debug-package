using TMPro;
using UnityEngine;

public enum PrintTypeVRC
{
    Clear,
    Append
}

public class VirtualRealityConsole : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI logText;

    static VirtualRealityConsole instance;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public static void PrintMessage(string message, PrintTypeVRC printType = PrintTypeVRC.Append)
    {
        if (printType == PrintTypeVRC.Clear)
        {
            instance.logText.text = message + '\n';
        }
        else if (printType == PrintTypeVRC.Append)
        {
            instance.logText.text += message + '\n';
        }
    }
}