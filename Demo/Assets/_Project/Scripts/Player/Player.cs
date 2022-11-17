using UnityEngine;

// в данном случае у нас сингл плэйер, второй нам не нужен. Синглтону быть.

public class Player : MonoBehaviour
{
    public static Player instance { get; private set; }

    public AudioSource audioSource;
    public GameObject vCameraGO;
    public Transform cameraTargetTF;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

}
