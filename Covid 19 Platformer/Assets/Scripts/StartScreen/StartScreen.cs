using UnityEngine;

class StartScreen : MonoBehaviour
{
    public string FirstLevel;

    public void Update()
    {
        if (!Input.GetMouseButtonDown(0))
        {
            return;
        }
        Application.LoadLevel(FirstLevel);
    }
}