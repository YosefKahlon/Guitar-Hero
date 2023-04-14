using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


/**
 * 
 */
[RequireComponent(typeof(TextMeshPro))]

public class NumberField : MonoBehaviour
{
    private int number;
    // Start is called before the first frame update
        
  public int GetNumber()
    {
        return this.number;
    }
    public void SetNumber(int value)
    {
        this.number = value;
        GetComponent<TextMeshPro>().text = "Score: "+ value.ToString();
    }


    public void AddNumber(int value)
    {
        SetNumber(this.number + value);
    }
}
