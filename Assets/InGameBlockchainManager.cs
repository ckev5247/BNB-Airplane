using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using UnityEngine.UI;
using TMPro;

public class InGameBlockchainManager : MonoBehaviour
{
    public string Address { get; private set; }
    public Button claimTokenBtn;
    public Button backBtn;
    public TextMeshProUGUI claimTokenBtnText;
    public TextMeshProUGUI tokenBalanceText;

    public GameObject gameControllerObject;
    private GameController gameControllerScript;

    private string gameSmartContractAddress = "0x5f8A7C7F55CC1Cb0A4ef03CfA0E741e8717E44F4";
    private string abiString = "[{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"GamePassGiven\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"newCount\",\"type\":\"uint256\"}],\"name\":\"TokenClaimed\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"claimGamePass\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"getToken\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"giveToken\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"hasGamePass\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]";

    void Start()
    {
        gameControllerScript = gameControllerObject.GetComponent<GameController>();
        tokenBalanceText.gameObject.SetActive(false);
    }

    public async void ClaimToken()
    {
        Debug.Log("Claim Token");
        claimTokenBtn.interactable = false;
        backBtn.interactable = false;
        claimTokenBtnText.text = "Claimming Token!";

        int score = 1;

        if (gameControllerScript != null)
        {
            score = gameControllerScript.score;
        }

        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();

        var contract = ThirdwebManager.Instance.SDK.GetContract(
            gameSmartContractAddress,
            abiString);
        await contract.Write("giveToken", Address, score);

        claimTokenBtnText.text = "Claim Token";

        int result = await contract.Read<int>("getToken", Address);

        tokenBalanceText.text = "Token Owned: " + result.ToString();

        tokenBalanceText.gameObject.SetActive(true);

        backBtn.interactable = true;
    }
}
