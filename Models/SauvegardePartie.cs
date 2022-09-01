using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public class SauvegardePartie
    {

        private string _path;
        private string _fileNamePartie = "sauvegardeJoueur.json";


        public SauvegardePartie()
        {
            var pathEnv = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            this._path = pathEnv;
        }



        public void SaveDataJoueur(Joueur joueur)
        {
          
            var fileAndPath = Path.Combine(this._path, _fileNamePartie);
            var json = JsonSerializer.Serialize(joueur);

            if (!File.Exists(fileAndPath))
            {
                File.WriteAllText(fileAndPath, json);
            }
            else
            {
                File.AppendAllText(fileAndPath, json);
            }
            

        }

        public void DeleteFileJoueur()
        {
            var fileAndPath = Path.Combine(this._path, _fileNamePartie);
            if (File.Exists(fileAndPath))
            {
                File.Delete(fileAndPath);
            }
        }
    }
}
