using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Vector3 collisionBoxSize;
    public int totalWheat;
    public Text wheatText;
    private static List<Collider2D> interactableObjects = new List<Collider2D>();
    public Collider2D selectedObject;
    public SpriteRenderer sr;
    public Animator animator;
    
    public static Player instance;

    private void Start()
    {
        instance = this;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

    }

    private void Update()
    {
        
        if (interactableObjects.Count > 0)
        {
            selectedObject = interactableObjects[0];
            foreach(var interactableObject in interactableObjects)
            {
                if (interactableObject.gameObject.CompareTag("Interactable"))
                {
                    if (Vector3.Distance(selectedObject.transform.position, transform.position) > Vector3.Distance(interactableObject.transform.position, transform.position))
                    {
                        selectedObject = interactableObject;
                        var cropManager = interactableObject.gameObject.GetComponent<CropManager>();
                        if (cropManager == null)
                        {
                            print("nulo");
                        }
                        else{
                            cropManager.isSelected = true;
                        }
                    }
                }
            }

            if (Vector3.Distance(selectedObject.transform.position, transform.position) > 0.5)
            {
                print(interactableObjects.Count + "itens deleted");
               // interactableObjects.Clear();
            }
            if(Input.GetKeyDown(KeyCode.Space)) {
                print("Selected Object " + selectedObject.name);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Interactable"))
        {
            print("added: " + collider);
            interactableObjects.Add(collider);
            var cropManager = collider.gameObject.GetComponent<CropManager>();
            if (cropManager == null)
            {
                print("nulo");
            }
            else{
                cropManager.isSelected = true;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Interactable"))
        {
            print(interactableObjects.Count + "itens deleted");
            var cropManager = collider.gameObject.GetComponent<CropManager>();
            if (cropManager == null)
            {
                print("nulo");
            }
            else{
                cropManager.isSelected = false;
            }
            interactableObjects.Clear();
        }
    }

    public bool canAnimatePlow()
    {
        if (interactableObjects.Count > 0 && !selectedObject.gameObject.GetComponent<CropManager>().isReady)
        {
            return true;
        }
        return false;
    }
    
    public bool canAnimatePlant()
    {
        if (interactableObjects.Count > 0 && !selectedObject.gameObject.GetComponent<CropManager>().hasSeed && selectedObject.gameObject.GetComponent<CropManager>().isReady)
        {
            return true;
        }
        return false;
    }
}
