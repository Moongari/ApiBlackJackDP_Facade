﻿using AppBlackJack_DPFacade.Interface;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppBlackJack_DPFacade.Models
{
    public class Regle : IRegle
    {
        private List<Cartes> ids;
        private readonly int nbreCarteParJoueur = 2;
        private int _iCompteurCarte = 0;
        Cartes? carte1;
        Cartes? carte2;

        public Regle()
        {
            ids = new List<Cartes>();
        }
        public void aGagne(List<Joueur> joueurs)
        {
            var maxValeur = joueurs.Max(j=> j.PointObtenu);

            var gagnant = joueurs.Where(j => j.PointObtenu == maxValeur).FirstOrDefault();
            
                
            
            Console.WriteLine($"\t le Vainqueur de la partie est : {gagnant.Name} - {gagnant.PointObtenu} Points ");
            
            
            

        }

        public IEnumerable<Tuple<string, string, int, Joueur>> distributionDesCartes(HashSet<Cartes> cartes, Joueur joueur)
        {

            Random rndCartes = new Random();


            for (int i = 0; i < nbreCarteParJoueur; i++)
            {
                int k = rndCartes.Next(1, 52);
                if (i == 0)
                {
                    carte1 = cartes.Where(c => c.id == k).FirstOrDefault();
                   
                }
                else
                {
                    carte2 = cartes.Where(c => c.id == k).FirstOrDefault();
                }


                


            }

            if (carte1 != null && carte2 != null)
            {
                joueur.PointObtenu = carte1.ValeurCarte + carte2.ValeurCarte;
                yield return new Tuple<string, string, int, Joueur>(carte1.Name, carte1.CarteType, carte1.ValeurCarte, joueur);
                yield return new Tuple<string, string, int, Joueur>(carte2.Name, carte2.CarteType, carte2.ValeurCarte, joueur);
            }












        }



        public void egaliteJoueur(List<Joueur> joueurs)
        {
            throw new NotImplementedException();
        }

        public bool isIdValid(Cartes idCartes)
        {
            if (!ids.Contains(idCartes))
            {
                ids.Add(idCartes);
                return true;
            }
            return false;

        }

        public bool isValidAge(List<Joueur> joueurs)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Cartes> melangeCartes(IEnumerable<Cartes> cartes)
        {
            Random rndCartes = new Random();
            int valMax = cartes.Count();
            while (ids.Count < valMax)
            {
                for (int i = cartes.Count() - 1; i >= 0; i--)
                {
                    int k = rndCartes.Next(1, cartes.Count() + 1);
                    var carteId = cartes.Where(c => c.id == k).First();
                    if (carteId != null)
                    {
                        if (isIdValid(carteId))
                        {

                            yield return new Cartes() { id = carteId.id, Name = carteId.Name, CarteType = carteId.CarteType, ValeurCarte = carteId.ValeurCarte };

                        }

                    }
                }


                var cardNotFirstList = cartes.Except(ids).ToList();
                //foreach (var item in cardNotFirstList)
                //{
                //    Console.WriteLine($" {item.id}");
                //}
            }
        }
    }
}
