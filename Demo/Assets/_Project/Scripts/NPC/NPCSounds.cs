using UnityEngine;

[CreateAssetMenu(fileName = "New NPS Sounds", menuName = "NPC/New Sounds")]

public class NPCSounds : ScriptableObject
{
    public string NPC_name = "NPC Name";
    public AudioClip qreetingClip = null;
    public AudioClip question1Clip = null;
    public AudioClip question2Clip = null;
    public AudioClip waitClip = null;
    public AudioClip welcomeClip = null;


}
