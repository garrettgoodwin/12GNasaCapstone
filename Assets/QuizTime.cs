using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    GameObject.Find("B1").GetComponentInChildren<Text>().text = "Irregular & Potato-like";
    GameObject.Find("B2").GetComponentInChildren<Text>().text = "Regular & Tomato-like";
    GameObject.Find("B3").GetComponentInChildren<Text>().text = "Regular & Onion-like";
    GameObject.Find("B4").GetComponentInChildren<Text>().text = "Irregular & Orange-like";
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
