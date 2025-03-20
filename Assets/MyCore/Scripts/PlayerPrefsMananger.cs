using UnityEngine;

public static class PlayerPrefsMananger
{
    public static void SaveInt(string intName, int number)
    {
        PlayerPrefs.SetInt(intName, number);
    }
    public static int LoadInt(string intName)
    {
        if (PlayerPrefs.HasKey(intName))
            return PlayerPrefs.GetInt(intName);
        else
        {
            Debug.Log("The key " + intName + " does not exist");
            return 0;
        } 
    }

    public static void SaveFloat(string floatName, float number)
    {
        PlayerPrefs.SetFloat(floatName, number);
    }
    public static float LoadFloat(string floatName)
    {
        if (PlayerPrefs.HasKey(floatName))
            return PlayerPrefs.GetFloat(floatName);
        else
        {
            Debug.Log("The key " + floatName + " does not exist");
            return 0;
        }
    }

    public static void SaveString(string stringName, string chars)
    {
        PlayerPrefs.SetString(stringName, chars);
    }
    public static string LoadString(string stringName)
    {
        if (PlayerPrefs.HasKey(stringName))
            return PlayerPrefs.GetString(stringName);
        else
        {
            Debug.Log("The key " + stringName + " does not exist");
            return "";
        } 
    }

    public static void SaveBool(string boolName, bool myBool)
    {
        PlayerPrefs.SetInt(boolName, myBool ? 1 : 0);
    }
    public static bool LoadBool(string boolName)
    {
        if (PlayerPrefs.HasKey(boolName))
            return PlayerPrefs.GetInt(boolName) == 1;
        else
        {
            Debug.Log("The key " + boolName + " does not exist");
            return false;
        }
    }

    public static void SaveColor(string colorName, Color color)
    {
        PlayerPrefs.SetString(colorName, ColorUtility.ToHtmlStringRGB(color));
    }
    public static Color LoadColor(string colorName)
    {
        Color color;

        if (PlayerPrefs.HasKey(colorName) && ColorUtility.TryParseHtmlString("#" + PlayerPrefs.GetString(colorName), out color))
            return color;
        else
        {
            Debug.Log("The key " + colorName + " does not exist");
            return new Color(1,1,1,1);
        }
    }

    public static void SaveVector3(string xName, string yName, string zName, Vector3 vector)
    {
        PlayerPrefs.SetFloat(xName, vector.x);
        PlayerPrefs.SetFloat(yName, vector.y);
        PlayerPrefs.SetFloat(zName, vector.z);
    }
    public static Vector3 LoadVector3(string xName, string yName, string zName)
    {
        float x, y, z;

        if (PlayerPrefs.HasKey(xName))
            x = PlayerPrefs.GetFloat(xName);
        else
        {
            Debug.Log("The key " + xName + " does not exist");
            return DefaultPosition();
        }

        if (PlayerPrefs.HasKey(yName))
            y = PlayerPrefs.GetFloat(yName);
        else
        {
            Debug.Log("The key " + yName + " does not exist");
            return DefaultPosition();
        }  

        if (PlayerPrefs.HasKey(zName))
            z = PlayerPrefs.GetFloat(zName);
        else
        {
            Debug.Log("The key " + zName + " does not exist");
            return DefaultPosition();
        }   

        return new Vector3(x,y,z);

        Vector3 DefaultPosition()
        {
            return new Vector3(0, 0, 0);
        }
    }

    public static void DeleteKey(string keyname)
    {
        PlayerPrefs.DeleteKey(keyname);
    }
    public static void DeleteAllKeys()
    {
        PlayerPrefs.DeleteAll();
    }
}