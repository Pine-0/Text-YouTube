using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class selectClip : MonoBehaviour
{

    private GameObject[] characterList;
    //to check which int position on characters it is on
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        index = PlayerPrefs.GetInt("CharacterSelected");

        characterList = new GameObject[transform.childCount];


        //fill are with models
        for (int i = 0; i < transform.childCount; i++)
        {
            characterList[i] = transform.GetChild(i).gameObject;
        }

        foreach (GameObject go in characterList)
            go.SetActive(false);

        //toggle selected character on   (THIS IS HOW A CHARACTER CHANGES FROM ONE CHAR TO ANOTHER)
        if (characterList[index])
            characterList[index].SetActive(true);

    }

    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            ToggleDown();

        }

        if (Input.GetKeyDown("left"))
        {
            ToggleUp();

        }
        else
        {
            StopAllCoroutines();
        }

    }

    /*PERFECTED LOOPABLE SELECTION SYSTEM*/

    public void ToggleDown()
    {
        //set current array object to false (off)
        characterList[index].SetActive(false);

        //in every instance, add array assignment by one (ex: 1-5, 1 to 0 to 5)
        index++;

        //if new array position greater than the number of objects in array (ie. 0 to 3), return to 1st object
        if (index > 3)
        {
            index = 0;
        }

        //activate new array position
        characterList[index].SetActive(true);

    }



    public void ToggleUp()
    {
        //set current array object to false (off)
        characterList[index].SetActive(false);

        //in every instance, reduce array assignment by one (ex: 1-5, 1 to 0 to 5)
        index--;

        //if new array position less than the number of objects in array (ie. 0 to 3), retun to last object
        if (index < 0)
        {
            index = 3;

        }

        //activate new array position
        characterList[index].SetActive(true);
    }



}
