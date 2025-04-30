using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement; // <-- added for scene loading
using System.Collections;
using TMPro;
using System.Text;
using System;

public class NetworkManager : MonoBehaviour
{
    private static NetworkManager _instance;
    private string serverUrl = "http://localhost:3000"; // Or your LAN IP for device testing

    public static NetworkManager Instance
    {
        get
        {
            if (_instance == null)
            {
                var go = new GameObject("NetworkManager");
                _instance = go.AddComponent<NetworkManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    // --- Register a new user (now includes password) ---
    public IEnumerator RegisterUser(string name, string email, string password, Action<string> callback)
    {
        // build {"name":"…","email":"…","password":"…"}
        var jsonData = $"{{\"name\":\"{name}\",\"email\":\"{email}\",\"password\":\"{password}\"}}";

        using (var req = new UnityWebRequest($"{serverUrl}/register", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            req.uploadHandler   = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");

            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
                callback(req.downloadHandler.text);
            else
                callback(req.error);
        }
    }

    // --- Login an existing user ---
    public IEnumerator LoginUser(string email, string password, Action<string> callback)
    {
        // build {"email":"…","password":"…"}
        var jsonData = $"{{\"email\":\"{email}\",\"password\":\"{password}\"}}";

        using (var req = new UnityWebRequest($"{serverUrl}/login", "POST"))
        {
            byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
            req.uploadHandler   = new UploadHandlerRaw(bodyRaw);
            req.downloadHandler = new DownloadHandlerBuffer();
            req.SetRequestHeader("Content-Type", "application/json");

            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
                callback(req.downloadHandler.text);
            else
                callback(req.error);
        }
    }

    // --- UI References (link these in the Inspector) ---
    public TMP_InputField nameInput;
    public TMP_InputField emailInput;
    public TMP_InputField passwordInput;
    public TMP_InputField confirmInput;
    public TMP_Text       resultText;

    // --- Login UI References (link these in the Inspector) ---
    public TMP_InputField loginEmailInput;
    public TMP_InputField loginPasswordInput;
    public TMP_Text       loginResultText;

    // Called by your “Continue” or “Register” button
    public void OnRegisterButtonPressed()
    {
        string name    = nameInput .text.Trim();
        string email   = emailInput.text.Trim();
        string pwd     = passwordInput.text;
        string confirm = confirmInput.text;

        // basic client-side validation
        if (string.IsNullOrEmpty(name) ||
            string.IsNullOrEmpty(email)||
            string.IsNullOrEmpty(pwd)  ||
            string.IsNullOrEmpty(confirm))
        {
            resultText.text = "Please fill out all fields.";
            return;
        }

        if (pwd != confirm)
        {
            resultText.text = "Passwords do not match.";
            return;
        }

        // fire off the POST /register
        StartCoroutine(
            Instance.RegisterUser(name, email, pwd, (response) =>
            {
                resultText.text = "Registered: " + response;
                Debug.Log("Server response: " + response);
            })
        );
    }

    // Called by your “Login” button
    public void OnLoginButtonPressed()
    {
        string email = loginEmailInput.text.Trim();
        string pwd   = loginPasswordInput.text;

        // basic client-side validation
        if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(pwd))
        {
            loginResultText.text = "Please fill out both fields.";
            return;
        }

        // fire off the POST /login
        StartCoroutine(
            Instance.LoginUser(email, pwd, (response) =>
            {
                // if your server returns something like "Invalid credentials"
                if (response.ToLower().Contains("error") || response.ToLower().Contains("invalid"))
                {
                    loginResultText.text = "Login failed: " + response;
                }
                else
                {
                    loginResultText.text = "Login success!";
                    Debug.Log("Server response: " + response);
                    // load your MainMenu scene
                    SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
                }
            })
        );
    }
}
