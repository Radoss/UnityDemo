using UnityEngine.UI;
using UnityEngine;

// Иконка компьютера. При клике проигрывает звук.

public class CompIcon : MonoBehaviour
{
    [SerializeField] AudioClip _clip;

    private void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate { OnCompIconBtnClick(); });
    }

    public void OnCompIconBtnClick()
    {
        AudioSource _source = Player.instance.audioSource;
        _source.clip = _clip;
        _source.Play();
    }

}
