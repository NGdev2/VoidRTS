using UnityEngine;

public class MenuManager : MonoBehaviour
{
	[SerializeField] private GameObject levelMenu;
	void Update()
    {
		if (Input.GetKeyDown(KeyCode.Escape) == true)
		{
	       levelMenu.SetActive(!levelMenu.activeSelf);
		}
    }
}
