using UnityEngine.UI;
using UnityEngine;

// Иконка компьютера. При клике проигрывает звук.

public class CompIcon : MonoBehaviour
{
    [SerializeField] AudioClip _clip;
    AudioSource _source;

    private void Start()
    {
        _source = Player.instance.audioSource;
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate { OnCompIconBtnClick(); });
    }

    public void OnCompIconBtnClick()
    {
        _source.clip = _clip;
        _source.Play();
    }

}
