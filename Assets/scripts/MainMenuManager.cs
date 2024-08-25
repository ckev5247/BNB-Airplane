using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Thirdweb;
using UnityEngine.UI;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public string Address { get; private set; }
    public Button playBtn;
    public Button passBtn;
    public TextMeshProUGUI passBtnText;

    private string gameSmartContractAddress = "0x5f8A7C7F55CC1Cb0A4ef03CfA0E741e8717E44F4";
    private string abiString = "[{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"GamePassGiven\",\"type\":\"event\"},{\"anonymous\":false,\"inputs\":[{\"indexed\":true,\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"},{\"indexed\":false,\"internalType\":\"uint256\",\"name\":\"newCount\",\"type\":\"uint256\"}],\"name\":\"TokenClaimed\",\"type\":\"event\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"claimGamePass\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"getToken\",\"outputs\":[{\"internalType\":\"uint256\",\"name\":\"\",\"type\":\"uint256\"}],\"stateMutability\":\"view\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"},{\"internalType\":\"uint256\",\"name\":\"amount\",\"type\":\"uint256\"}],\"name\":\"giveToken\",\"outputs\":[],\"stateMutability\":\"nonpayable\",\"type\":\"function\"},{\"inputs\":[{\"internalType\":\"address\",\"name\":\"player\",\"type\":\"address\"}],\"name\":\"hasGamePass\",\"outputs\":[{\"internalType\":\"bool\",\"name\":\"\",\"type\":\"bool\"}],\"stateMutability\":\"view\",\"type\":\"function\"}]"
;

    private void Start()
    {
        playBtn.gameObject.SetActive(false);
        passBtn.gameObject.SetActive(false);
    }

    public async void CheckTokenGatePass()
    {
        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();
        //For Testing
        //Address = "0x4C6F5f4e21840f1e103fF8791AC70b4Ff1AD59f9";
        var contract = ThirdwebManager.Instance.SDK.GetContract(
            gameSmartContractAddress,
            abiString
            );
        bool ishaveTokenGatePass = await contract.Read<bool>("hasGamePass", Address);

        if (ishaveTokenGatePass == true)
        {
            playBtn.gameObject.SetActive(true);
            passBtn.gameObject.SetActive(false);
        }
        else
        {
            playBtn.gameObject.SetActive(false);
            passBtn.gameObject.SetActive(true);
        }
    }

    public async void GetGamePass()
    {
        Debug.Log("Get GamePass");
        passBtn.interactable = false;
        passBtnText.text = "Claimming Pass!";

        Address = await ThirdwebManager.Instance.SDK.Wallet.GetAddress();

        var contract = ThirdwebManager.Instance.SDK.GetContract(
            gameSmartContractAddress,
            abiString);
        await contract.Write("claimGamePass", Address);

        passBtn.interactable = true;
        passBtnText.text = "Claim Pass";

        playBtn.gameObject.SetActive(true);
        passBtn.gameObject.SetActive(false);
    }

}
