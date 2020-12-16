using TMPro;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    public Item Item => item;
    [SerializeField] Canvas canvas = default;
    [SerializeField] public Item item = default;
    Vector3 playerRotation;
    bool shouldDisplayInfo = false;
    [SerializeField] TMP_Text tmpText = default;
    [SerializeField] float offset = 2f;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldDisplayInfo = true;
            widgetItem();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            shouldDisplayInfo = false;
            hideWidgetItem();
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (shouldDisplayInfo)
        {
            playerRotation = other.transform.localRotation.eulerAngles;
            canvas.transform.eulerAngles = playerRotation;
            canvas.transform.localPosition = transform.localPosition;
            canvas.transform.Translate(Vector3.right * offset, Space.Self);
        }
    }
    void widgetItem()
    {

        tmpText.gameObject.SetActive(true);
        

        tmpText.text = $"Name : {item.Name}\n Weight: {item.Weight}kg\nPress \"{KeyCode.E}\" to pick up";
    }
    public void hideWidgetItem()
    {
        tmpText.gameObject.SetActive(false);
    }
}
