using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameManager : MonoBehaviour
{
    public CreateRooms boardScript;

    private void Awake()
    {
        boardScript.SetupScene(1);
    }
}
