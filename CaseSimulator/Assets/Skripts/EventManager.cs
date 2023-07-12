using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public static event Action MusicChanged;
    public static event Action CaseOpened;

    public static void OnMusicChanged()
    {
        MusicChanged?.Invoke();
    }
    public static void OnCaseOpened()
    {
        CaseOpened?.Invoke();
    }
}
