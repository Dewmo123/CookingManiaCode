using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseStorage : MonoBehaviour
{
    public GameObject _inventory1;
    public GameObject _inventory2;
    public void ItemChoose(Item chosenItem)
    {
        ChosenInven inven1 = _inventory1.GetComponent<ChosenInven>();
        ChosenInven inven2 = _inventory2.GetComponent<ChosenInven>();
        if (inven1._chosenItem==null)
        {
            inven1.ItemChoose(chosenItem);
        }
        else if (inven2._chosenItem==null)
        {
            inven2.ItemChoose(chosenItem);
        }

    }
}
