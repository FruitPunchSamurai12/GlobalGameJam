using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIMemoryFragments : MonoBehaviour
{
    TextMeshProUGUI text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        GameManager.Instance.OnMemoryFragmentsChanged += HandleMemoryFragmentsChanged;
        text.SetText($"x {GameManager.Instance.MemoryFragments}/6");
    }

    void HandleMemoryFragmentsChanged(int memoryFragments)
    {
        text.SetText($"x {memoryFragments}/6");
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnMemoryFragmentsChanged -= HandleMemoryFragmentsChanged;
    }
}
