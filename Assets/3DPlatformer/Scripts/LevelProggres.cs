using UnityEngine;

public class LevelProggres : MonoBehaviour
{
    [SerializeField] private GameObject[] stars;

    public void OpenStar()
    {
        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[i].activeSelf == false)
            {
                stars[i].SetActive(true);
                return;
            }
        }
    }

    public int GetStarsCount()
    {
        return stars.Length;
    }

    public int GetOpenStarsCount()
    {
        int openStarsCount = 0;
        for (int i = 0; i < stars.Length; i++)
        {
            if (stars[i].activeSelf == true)
            {
                openStarsCount++;
            }
        }
        return openStarsCount;
    }
}
