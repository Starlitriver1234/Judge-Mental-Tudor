using UnityEngine;
using DialogueEditor;

public class SkipOptionButton : MonoBehaviour
{
    public void OnSkipPressed()
    {
        var manager = ConversationManager.Instance;
        if (manager != null)
        {
            manager.FastForwardCurrentLine();
        }
    }
}
