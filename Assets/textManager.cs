using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class textManager : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if(textComponent.text == lines[index])
            {
                nextLine();
            }
            else
            {
                StopAllCoroutines();  
                textComponent.text = lines[index];
            }
        }


        /*
    //If the stuff we aree talking about is done, spawn a next topic> button
        if (lines[index] == "")
        {
            nextLine();
        }
        */




    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void nextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }

        else
        {
            gameObject.SetActive(false);
        }
    }
}
