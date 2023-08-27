using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{


    public BitArray TM = new(96);
    public BitArray HM = new(8);
    public BitArray keyItem = new(0);

    Pokemon[] Party = new Pokemon[6];
    int monsInParty = 0;


    private IEnumerator OnItemGet(ushort item)
    {
        switch (Item.ItemTable[item].type)
        {
            case ItemType.TM:
                //yield return Field.Announce("Received" + Item.ItemTable[item].name");
                TM[Item.ItemTable[item].itemData.tmID] = true;
                break;
            default:
                break;
        }
        yield return null;
    }

    private bool TryAddMon(Pokemon mon)
    {
        SortParty();
        if(monsInParty >= 6)
        {
            return false;
        }
        else
        {
            Party[monsInParty] = mon;
            SortParty();
            return true;
        }
    }

    private void SortParty()
    {
        int currentPos = 0;
        for(int i = 0; i < 6; i++)
        {
            if (Party[i].exists)
            {
                Party[currentPos] = Party[i];
                currentPos++;
            }
        }
        monsInParty = currentPos;
        for (int i = currentPos; i < 6; i++)
        {
            Party[i] = Pokemon.MakeEmptyMon;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
