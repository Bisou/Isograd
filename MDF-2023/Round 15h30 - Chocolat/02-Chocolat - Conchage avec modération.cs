using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Chocolat - Conchage avec modération

Votre opération de partage de tablette a éveillé en vous une véritable vocation, vous décidez donc de vous lancer dans la production et distribution de chocolat à grande échelle. Pour affiner votre produit, vous disposez de plusieurs machines qui brassent la pâte de cacao pendant des heures : c'est l'étape de conchage.

Chaque machine possède sa propre capacité (la quantité de pâte de cacao qu'elle peut affiner pendant la durée du processus), mais curieusement, toutes les machines ont la même consommation électrique. Vos besoins en pâte de cacao sont limités, vous pouvez donc vous permettre d'éteindre certaines machines pour économiser de l'énergie. Quel est le nombre minimum de machines dont vous avez besoin pour affiner au moins la quantité souhaitée de pâte de cacao ?
Données
Entrée

Ligne 1 : deux entiers :

    N, le nombre de machines (compris entre 1 et 1000)
    P, la quantité de pâte de cacao en litres que vous souhaitez affiner lors d'une étape de conchage (comprise entre 1 et 2 000 000)

N lignes suivantes : un entier C compris entre 1 et 1000 : la capacité de l'une des machines (en litres)
Sortie

Un entier : le nombre minimum de machines nécessaires pour affiner suffisamment de pâte de cacao.

S'il n'est pas possible d'affiner la quantité voulue de pâte même avec toutes les machines, affichez IMPOSSIBLE à la place de la réponse.
Exemples

Pour l'entrée :

3 50
48
5
5

La sortie attendue est :

2

En effet, au moins 2 machines sont nécessaires pour atteindre l'objectif de 50 litres : la machine de capacité 48 et l'une des deux machines de capacité 5.

Si on fixe maintenant P = 60 :

3 60
48
5
5

La sortie attendue est :

IMPOSSIBLE

En effet, utiliser toutes les machines permet seulement d'atteindre une capacité totale de 48 + 5 + 5 = 58 litres, ce qui est inférieur à l'objectif de 60 litres.


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
            var data = Console.ReadLine().Split(' ');
            var n = int.Parse(data[0]);
            var cocoaPaste = int.Parse(data[1]);
            var machines = new List<int>();
            string line;
            while ((line = Console.ReadLine()) != null) {
                machines.Add(int.Parse(line));
            }
            var neededMachines = 0;
            foreach (var machine in machines.OrderByDescending(x => x)) {
                cocoaPaste -= machine;
                neededMachines++;
                if (cocoaPaste <= 0) break;
            }
            
            if (cocoaPaste <= 0)
                Console.WriteLine(neededMachines);
            else
                Console.WriteLine("IMPOSSIBLE");
        }
    }
}
