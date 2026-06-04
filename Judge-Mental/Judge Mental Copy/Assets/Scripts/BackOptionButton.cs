using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class BackOptionButton : MonoBehaviour
{
 public void OnBackPressed()
    {
        var manager = ConversationManager.Instance;
        if (manager == null) return;

        manager.GoToPreviousSpeech();
    }
}
