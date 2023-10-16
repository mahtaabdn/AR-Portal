//--------------------------------
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//--------------------------------
public class QuestGiver : MonoBehaviour
{
    //--------------------------------
    //Human readable quest name
    public string QuestName = string.Empty;
    //Reference to UI Text Box
    public Text Captions = null;
    //List of strings to say
    public string[] CaptionText;
    //--------------------------------
    void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        Quest.QUESTSTATUS Status = QuestManager.GetQuestStatus(QuestName);
        Captions.text = CaptionText[(int)Status]; //Update GUI text
    }
    //--------------------------------
    void OnTriggerExit(Collider other)
    {
        Quest.QUESTSTATUS Status = QuestManager.
        GetQuestStatus(QuestName);
        if (Status == Quest.QUESTSTATUS.UNASSIGNED)
            QuestManager.SetQuestStatus(QuestName, Quest.QUESTSTATUS.
            ASSIGNED);
        if (Status == Quest.QUESTSTATUS.COMPLETE)
            SceneManager.LoadScene(5); //Game completed, go to win screen
    }
}
//--------------------------------