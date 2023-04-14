using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class GameSystem : MonoBehaviour
{
    [SerializeField] InputAction Button = new InputAction(type: InputActionType.Button);
    GameObject cube;
    [SerializeField] Color orignalColor;
    [SerializeField] Color wasPressedColor;
    [SerializeField] bool CanPress;
    [SerializeField] NumberField scoreField;
    [SerializeField] int pointToAdd;

    void OnEnable()
    {
        Button.Enable();

    }

    void OnDisable()
    {
        Button.Disable();

    }

    // Update is called once per frame
    void Update()
    {   
        var cubeRenderer = this.GetComponent<Renderer>();

        if (Button.WasPressedThisFrame())
        {

            Debug.Log(Button);
            // Get the Renderer component from the new cube
            if (CanPress)
            {
                scoreField.AddNumber(pointToAdd);
              //  gameObject.SetActive(false);
            }


            // Call SetColor using the shader property name "_Color" and setting the color to the custom color you created
            cubeRenderer.material.SetColor("_Color", wasPressedColor);

        }
        if (Button.WasReleasedThisFrame())
        {
            cubeRenderer.material.SetColor("_Color", orignalColor);
        }
    }


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (this.tag == other.gameObject.tag)
        {
            CanPress = true;
            Debug.Log(tag);

        }



    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (tag == other.gameObject.tag)
        {
            CanPress = false;
            Debug.Log("no tag");

        }
    }

    public void SetScoreField(NumberField newtextField)
    {
        this.scoreField = newtextField;
    }
}
