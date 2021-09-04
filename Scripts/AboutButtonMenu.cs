using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AboutButtonMenu : MonoBehaviour
{
	public void MenuToAbout()
	{
		SceneManager.LoadScene(1);
	}
}
