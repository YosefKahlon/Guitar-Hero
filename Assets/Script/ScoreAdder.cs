using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAdder : MonoBehaviour
{
    [Tooltip("Every oblect tagged with this tag will trigger adding score to the field.")]
    [SerializeField] string triggeringTag;
    [SerializeField] NumberField scoreField;
    [SerializeField] int pointToAdd;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == this.tag)
        {
            scoreField.AddNumber(pointToAdd);
        }
    }

    public void SetScoreField(NumberField newtextField)
    {
        this.scoreField = newtextField;
    }
}
