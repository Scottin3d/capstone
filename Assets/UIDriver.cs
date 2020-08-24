using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class UIDriver : MonoBehaviour
{
    public Text speed;

    public playerAttributes player;
    // Update is called once per frame
    void Update()
    {
        UpdateSpeed();
    }

    public void UpdateSpeed() {
        speed.text = player.speed.ToString();
    }
}

