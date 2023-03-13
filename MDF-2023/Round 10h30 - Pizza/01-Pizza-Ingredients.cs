using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Pizza - Ingrédients

Ca y est le grand jour est arrivé, aujourd'hui vous ouvrez votre pizzeria ! Tout est prêt, vos premiers clients arrivent.

Mais horreur, vous vous rendez compte que vous avez oublié le plus important : vous n'avez pas fait les courses des ingrédients !

Vite, vous regardez votre menu et écrivez votre liste de courses : à partir des recettes de votre menu, écrivez un programme qui renvoie le nombre d'ingrédients différents à acheter.
Données
Entrée

Ligne 1 : un entier N compris entre 1 et 20, représentant le nombre de recettes à la carte

N lignes suivantes : une recette par ligne. Chaque recette est composée de 3 ingrédients séparés par des espaces. Chaque ingrédient est un mot composée de lettres minuscules.
Sortie

Le nombre d'ingrédients différents dans toutes les recettes.
Exemple

Pour l'entrée :

3
tomato mozzarella ham
tomato pineapple ham
cream pepper mushroom

La sortie attendue est :

7

En effet, il y a 7 ingrédients différents dans les 3 recettes : tomato, mozzarella, ham, pineapple, cream, pepper et mushroom. 

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
            var ingredients = new HashSet<string>();
            string line;
            while ((line = Console.ReadLine()) != null) {
                foreach(var ingredient in line.Split(' '))
                    ingredients.Add(ingredient);
            }

            Console.WriteLine(ingredients.Count());
        }
    }
}
