using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;


public class InterpreterCrypto : MonoBehaviour
{

      Dictionary<string, string> colors = new Dictionary<string, string>()
    {
        { "black", "#021b21" },
        { "gray", "#555d71" },
        { "red", "#ff5879" },
        { "yellow", "#f2f1b9" },
        { "blue", "#9ed9d8" },
        { "purple", "#d926ff" },
        { "orange", "#ef5847" }
    };

    List<string> response = new List<string>();
    public DownloadManager downloadManager;
    public List<string> Interpret(string userInput)
    {
        response.Clear();
        string[] args = userInput.Split();

        if( args[0] == "help")
        {
            ListEntry("help","pour avoir la liste des commandes disponile");
            ListEntry("ls","afficher l'historique des mail'");
            ListEntry("dl + [filename]","télécharger le mail ");
            return response;

        }

        else if ( args[0] == "ls")
        {
            response.Add("Historique des mails: 11_05_2024, 12_05_2024, 16_05_2024, 20_05_2024");
            return response;
        }

        
        else if (args[0] == "dl") 
        {
            if (args.Length >= 2) 
            {
                if (args[1] == "11_05_2024") 
                {
                    string url = "https://github.com/Yousrachn/ProjetE4/raw/main/Fichiers/11_05_2024.pdf";
                    DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                    DownloadManager.DownloadURLfrom(url);
                    response.Add("Opération réussie");
                    return response;
                }

                else if (args[1] == "12_05_2024") {
                    string url = "https://github.com/Yousrachn/ProjetE4/raw/main/Fichiers/12_05_2024.pdf";
                    DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                    DownloadManager.DownloadURLfrom(url);
                    response.Add("Opération réussie");
                    return response;
                }

                else if (args[1] == "16_05_2024") {
                    string url = "https://github.com/Yousrachn/ProjetE4/raw/main/Fichiers/16_05_2024.pdf";
                    DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                    DownloadManager.DownloadURLfrom(url);
                    response.Add("Opération réussie");
                    return response;
                }

                else if (args[1] == "20_05_2024") {
                    string url = "https://github.com/Yousrachn/ProjetE4/raw/main/Fichiers/20_05_2024.pdf";
                    DownloadManager DownloadManager = gameObject.GetComponent<DownloadManager>();
                    DownloadManager.DownloadURLfrom(url);
                    response.Add("Opération réussie");
                    return response;
                }

                else
                {
                    response.Add("Le fichier spécifié n'existe pas");
                    return response;
                }
            }
                    
            else
            {
                response.Add("Commande incomplète.");
                return response;
            }
        }
        
        else 
        {
            
            response.Add("Commande non reconnue. Entrer help pour avoir la liste des commandes.");
            return response;
        }
    }


    public string ColorString(string s,string color)
    {
        string leftTag = "<color=" + color + ">";
        string rightTag = "</color>";
        return leftTag + s + rightTag;

    }

    void ListEntry(string a, string b)
    {
        response.Add(ColorString(a, colors["orange"]) + ":" + ColorString(b, colors["yellow"]));

    }

    void LoadTitle(string path, string color, int spacing)
    {
        string fullPath = Path.Combine(Application.streamingAssetsPath, path);
        if (File.Exists(fullPath))
        {
            StreamReader file = new StreamReader(fullPath);


            for(int i = 0; i<spacing; i++)
            {
                response.Add("");

            }
            while(!file.EndOfStream)
            {
                response.Add(ColorString(file.ReadLine(), colors[color]));

            }
            for(int i = 0; i<spacing; i++)
            {
                response.Add("");
            }
            file.Close();
        }
        else
        {
            Debug.LogError("File not found: " + fullPath); // Debug
            response.Add("File not found: " + path);
        }
    }
}

