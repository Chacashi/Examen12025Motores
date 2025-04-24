using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Points UI")]
    [SerializeField] private TMP_Text textPoints;


    [Header("Life UI")]
    [SerializeField] private Slider sliderLife;


    [SerializeField] private PlayerController player;



    private void Start()
    {
       
        sliderLife.value = player.MaxLife;
        sliderLife.maxValue = player.MaxLife;
        textPoints.text = "Puntos: " + player.CurrentPointsPlayer;
    }


    private void OnEnable()
    {
        PlayerController.OnPlayerTakeHeart += SetPoitnsToSlider;
        PlayerController.OnPlayerReceiveDamage += SetPoitnsToSlider;
        PlayerController.OnPlayerTakeCoin += SetPointsToTextCoins;
    }

    private void OnDisable()
    {
        PlayerController.OnPlayerTakeHeart -= SetPoitnsToSlider;
        PlayerController.OnPlayerReceiveDamage -= SetPoitnsToSlider;
        PlayerController.OnPlayerTakeCoin -= SetPointsToTextCoins;
    }
    void SetPoitnsToSlider()
    {
        sliderLife.value = player.CurrentLife;
    }
    void SetPointsToTextCoins()
    {
        textPoints.text = "Puntos: " + player.CurrentPointsPlayer;
    }
}
