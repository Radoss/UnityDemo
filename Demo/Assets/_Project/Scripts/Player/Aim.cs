using UnityEngine;
using UnityEngine.UI;
using InteractionSystem;

// Прицел

public class Aim : MonoBehaviour
{
    //Ссылка на курсор в центре экрана, ссылка на картинку на канвасе
    [SerializeField] Image _aimImage; 

    Camera _mainCamera; 

    private void Awake()
    {
        _mainCamera = Camera.main;
    }

    private void Start()
    {
        GameEvents.instance.onShowInventoryRequested += onShowInventoryRequested;
        GameEvents.instance.onHideAimRequested += onHideAimRequested;
    }

    private void onShowInventoryRequested()
    {
        _aimImage.gameObject.SetActive(true);
    }

    private void onHideAimRequested()
    {
        _aimImage.gameObject.SetActive(false);
    }

    /* Рейкастим с цетра экрана, если натыкаемся на interractable, 
     * если расстояние позволяет, красим прицел красным. 
     * Если зажата E, то взаимодействуем
     */
    private void Update()
    {
        RaycastHit hit;
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        _aimImage.color = Color.gray;

        if (Physics.Raycast(ray, out hit))
        {
            Transform objectHit = hit.transform;
            Iinteractable interractable;
            if (objectHit.TryGetComponent<Iinteractable>(out interractable))
            {
                if (hit.distance < interractable.radius)
                {
                    _aimImage.color = Color.red;
                    if (Input.GetKeyDown(KeyCode.E))
                    {
                        interractable.Interact();
                    }
                }
            }
        }
    }
}
