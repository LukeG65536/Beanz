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
            PlayerInv inv = player.GetComponent<PlayerInv>();
            inv.resetInv();
            inv.cash += moneyMade * inv.upgrades["Cash Multi"][0] * inv.upgrades["Bean Multi"][0] * inv.upgradesRebirth["Cash Multi R"][0] * inv.upgradesRebirth["Bean Multi R"][0];
        }
    }
}
