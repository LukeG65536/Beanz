using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cashTextObj;
    public TextMeshPro cashText;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        cashText = cashTextObj.GetComponent<TextMeshPro>();
    }

    // Update is called once per frame
    void Update()
    {
        //cashText.text = player.GetComponent<PlayerInv>().cash;
    }
}
