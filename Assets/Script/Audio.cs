using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Audio : MonoBehaviour
{
    [SerializeField] AudioSource audio;
    [SerializeField] bool play = true;
    [SerializeField] InputAction playButton = new InputAction(type: InputActionType.Button);
    [SerializeField] InputAction stopButton = new InputAction(type: InputActionType.Button);
    private float audioTime = 0f;

    // Start is called before the first frame update
    void Start()
    {

    }

    void OnEnable()
    {
        playButton.Enable();
        stopButton.Enable();
    }

    void OnDisable()
    {
        playButton.Disable();
        stopButton.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if (play)
        {
            if (playButton.WasPressedThisFrame())
            {
                if (audioTime > 0f) // Resume from where the audio left off
                {
                    audio.time = audioTime;
                }
                else
                {
                    audio.Play(); // Start from the beginning if it's the first time playing
                }
                play = false;
            }
        }
        else
        {
            if (stopButton.WasPressedThisFrame())
            {
                audioTime = audio.time; // Store the current playback time
                play = true;
                audio.Stop();
            }
        }

    }


}
