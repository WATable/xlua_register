using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DonDestroyLoad : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
