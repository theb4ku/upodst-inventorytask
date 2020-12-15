using TMPro;
using UnityEngine;

public class ItemGiver : MonoBehaviour
{
    [SerializeField] Canvas canvas = default;
    [SerializeField] public Item item = default;
    Vector3 playerRotation;

    [SerializeField] TMP_Text tmpText = default;


    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRotation = other.transform.localRotation.eulerAngles;
            widgetItem();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hideWidgetItem();
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void widgetItem()
    {

        tmpText.gameObject.SetActive(true);
        canvas.transform.eulerAngles = playerRotation;

        canvas.transform.localPosition = this.transform.localPosition;
        canvas.transform.Translate(Vector3.right * 1.5f, Space.Self);

        tmpText.text = $"Name : {item.Name}\n Weight: {item.Weight}";
    }
    public void hideWidgetItem()
    {
        tmpText.gameObject.SetActive(false);
    }
}
