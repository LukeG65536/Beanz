using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject player;
    public GameObject cashTextObj;
    public TextMeshProUGUI cashText;
    GameObject[] buttons;
    // Start is called before the first frame update
    void Start()
    {
        buttons = GameObject.FindGameObjectsWithTag("Button");
    }

    // Update is called once per frame
    void Update()
    {
        cashText.text = Mathf.Round((float)player.GetComponent<PlayerInv>().cash).ToString();
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            setButtons(true);
        }

        if (Input.GetKeyUp(KeyCode.Tab))
        {
            setButtons(false);
        }
    }

    public void setButtons(bool set)
    {
        foreach (var obj in buttons)
        {
            obj.SetActive(set);
        }
    }
}
