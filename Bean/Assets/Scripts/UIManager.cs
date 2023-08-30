using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cashTextObj;
    public TextMeshProUGUI cashText;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        cashText.text = Mathf.Round((float)player.GetComponent<PlayerInv>().cash).ToString();
    }
}
