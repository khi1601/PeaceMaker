using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPHeart : MonoBehaviour
{

    [SerializeField]
    private Sprite Heart;

    Image heartImage;

    private void Awake()
    {
        heartImage = GetComponent<Image>();
        heartImage.sprite = Heart;
    }
    public void SetHeartImg(HeartStatus status)
    {
        switch (status)
        {
            case HeartStatus.Empty:
                heartImage.fillAmount = 0.0f;
                break;
            case HeartStatus.OneQuarters:
                heartImage.fillAmount = 0.25f;
                break;
            case HeartStatus.TwoQuarters:
                heartImage.fillAmount = 0.5f;
                break;
            case HeartStatus.ThreeQuarters:
                heartImage.fillAmount = 0.75f;
                break;
            case HeartStatus.FourQuarters:
                heartImage.fillAmount = 1.0f;
                break;
        }
    }

}
public enum HeartStatus
{
    Empty = 0,
    OneQuarters = 1,
    TwoQuarters = 2,
    ThreeQuarters = 3,
    FourQuarters = 4
}
