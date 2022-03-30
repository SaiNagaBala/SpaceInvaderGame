using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    // Start is called before the first frame update
    
    public Button startButton;
    public Button instructionButton;
    public Button backButton;
    public GameObject instruction;
    public GameObject start;
    void Start()
    {
        
        startButton.onClick.AddListener(GamePage);
        instructionButton.onClick.AddListener(Instruction);
        backButton.onClick.AddListener(Back);
    }

    private void Back()
    {
        instruction.SetActive(false);
        start.SetActive(true);
    }

    private void GamePage()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void Instruction()
    {
        instruction.SetActive(true);
        start.SetActive(false);
        //SceneManager.LoadScene(1);

    }

    // Update is called once per frame
   
}
