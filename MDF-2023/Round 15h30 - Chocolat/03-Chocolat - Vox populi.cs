using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Chocolat - Vox populi

Votre business chocolatier est maintenant lancé et tourne très bien ! Vous décidez de célébrer ce succès avec une création unique, adaptée aux goûts de vos fidèles clients.

Comme tout bon commerçant, vous connaissez bien vos clients - vous avez notamment mémorisé les trois ingrédients préférés de chacun d'entre eux. Pour qu'un client soit satisfait, il faut que votre création contienne au moins un de ses trois ingrédients préférés. Cependant, vous devez aussi limiter la diversité d'ingrédients pour éviter les combinaisons douteuses...

Pouvez-vous déterminer le plus petit nombre d'ingrédients qui permet de satisfaire tous les clients ?
Données
Entrée

Ligne 1 : un entier N compris entre 1 et 50 : le nombre de clients

N lignes suivantes : trois mots composés de lettres minuscules et séparés par des espaces : les trois ingrédients préférés de l'un des clients.

Le nombre d'ingrédients différents sur l'ensemble des clients ne dépasse pas 13.
Sortie

Un entier : le nombre minimum d'ingrédients différents à utiliser pour que la création contienne au moins l'un des ingrédients préférés de chaque client.
Exemple

Pour l'entrée :

3
almond pepper lemon
nougat hazelnut pepper
milk almond orange

La sortie attendue est :

2

En effet, un seul ingrédient ne suffit pas car aucun ingrédient n'est le favori des trois clients à la fois. On peut par contre trouver plusieurs solutions avec deux ingrédients, par exemple :

    pepper (pour les clients 1 et 2) et milk (pour le client 3)
    almond (pour les clients 1 et 3) et nougat (pour le client 2).


 * Read input from Console
 * Use: Console.WriteLine to output your result to STDOUT.
 * Use: Console.Error.WriteLine to output debugging information to STDERR;
 *       
 * ***/

namespace CSharpContestProject
{
    class Program
    {
        static void Main(string[] args)
        {   
            var n = int.Parse(Console.ReadLine());
            var allIngredients = new Dictionary<string, int>();
            var allIngredientsByIndex = new List<string>();
            var index=0;
            var clients = new List<string[]>();
            for (var i=0;i<n;++i) {
                var client = Console.ReadLine().Split(' ');
                clients.Add(client);
                foreach(var ingredient in client)
                    if (!allIngredients.ContainsKey(ingredient)) {
                        allIngredientsByIndex.Add(ingredient);
                        allIngredients.Add(ingredient, index++);
                    }
            }
            
            var selectedIngredients = new List<List<string>>();
            selectedIngredients.Add(new List<string>()); //start with an empty list of ingredients
            
            while(true) {
                //add ingredients one at a time
                var toBeAdded = new List<List<string>>();
                foreach (var ingredients in selectedIngredients) {
                    var start=0;
                    if (ingredients.Any()) start = allIngredients[ingredients.Last()] + 1;
                    for (var i=start;i<allIngredients.Count();++i) {
                        var newList = ingredients.ToList();
                        newList.Add(allIngredientsByIndex[i]);
                        toBeAdded.Add(newList);
                    }
                }
                selectedIngredients = toBeAdded;
                
                foreach (var ingredientList in selectedIngredients) {
                    if (clients.All(client => client.Intersect(ingredientList).Any())) {
                        Console.WriteLine(ingredientList.Count());
                        return;
                    }
                }
            }
        }
    }
}
