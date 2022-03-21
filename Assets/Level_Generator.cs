using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level_Generator : MonoBehaviour
{
    public static void GenerateLevel()
    {
        Destroy(GameObject.Find("Wood"));
        Destroy(GameObject.Find("1"));
        Destroy(GameObject.Find("2"));
        Destroy(GameObject.Find("3"));
        Destroy(GameObject.Find("Wood"));
    }
}
