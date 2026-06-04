using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkFile;                             // Assign your Ink .json file here
    public TextMeshProUGUI textBox;                       // Assign the TMP text UI here
    public GameObject[] choiceButtons;                    // Assign 4 buttons here

    private Story story;

    void Start()
    {
        if (inkFile != null)
        {
            story = new Story(inkFile.text);
            ContinueStory(); // Optional: show first line on start
        }
        else
        {
            Debug.LogError("Ink file not assigned!");
        }
    }

    void Update()
    {
        if (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.Space))
        {
            ContinueStory();
        }
    }

    private void ContinueStory()
    {
        if (story == null)
        {
            Debug.LogError("Story not initialized.");
            return;
        }

        if (story.canContinue)
        {
            textBox.gameObject.SetActive(true);
            textBox.text = story.Continue();
            ShowChoices();
        }
        else
        {
            FinishDialogue();
        }
    }

    private void ShowChoices()
    {
        List<Choice> choices = story.currentChoices;
        int index = 0;

        foreach (Choice c in choices)
        {
            choiceButtons[index].GetComponentInChildren<TextMeshProUGUI>().text = c.text;
            choiceButtons[index].SetActive(true);
            index++;
        }

        // Hide any remaining unused buttons
        for (int i = index; i < choiceButtons.Length; i++)
        {
            choiceButtons[i].SetActive(false);
        }
    }

    // ✅ This method can now be selected in the Unity Button OnClick inspector
    public void SetDecision(int choiceIndex)
    {
        if (story == null) return;

        story.ChooseChoiceIndex(choiceIndex);
        ContinueStory();
    }

    private void FinishDialogue()
    {
        textBox.gameObject.SetActive(false);

        foreach (var button in choiceButtons)
        {
            button.SetActive(false);
        }

        Debug.Log("Dialogue finished.");
    }
}
