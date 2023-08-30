using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class ShopController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            GameObject player = other.gameObject;
            int moneyMade = 0;
            foreach (var item in player.GetComponent<PlayerInv>().backPack)
            {
                moneyMade += item.Value[0] * item.Value[1];
            }
            player.GetComponent<PlayerInv>().resetInv();
            player.GetComponent<PlayerInv>().cash += moneyMade * player.GetComponent<PlayerInv>().upgrades["Cash Multi"][0] * player.GetComponent<PlayerInv>().upgrades["Bean Multi"][0];
        }
    }
}
