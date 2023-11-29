using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConScript : MonoBehaviour
{
    public bool win = false, gameOver = false;
    
    void Start()
    {
        win = false;
    }

    public void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(!gameOver)
            {
            win = true;
            }
        }
    }

    void Update()
    {
        win = win;
    }
}
