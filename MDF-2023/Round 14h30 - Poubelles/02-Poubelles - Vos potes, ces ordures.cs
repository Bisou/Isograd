using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Poubelles - Vos potes, ces ordures !

Il est 22h et, après une soirée de folie, enfin votre pendaison de crémaillère est terminée ! Malheureusement, vos invités ont laissé traîner des bouteilles de jus d'Abricot, de Banane et de Carotte et évidemment c'est à vous de tout jeter !

Vous voilà arrivé·e devant le local poubelle, et son système de recyclage révolutionnaire : il y a deux poubelles à votre disposition, la bleue et la rouge. La poubelle bleue peut recevoir des bouteilles de jus d'Abricot et de Banane, alors que la rouge peut recevoir des bouteilles de jus de Banane et de Carotte.

Chaque poubelle peut contenir autant de bouteilles, et vous avez minutieusement compté combien vous possédez de bouteilles de chaque type : comment assigner vos bouteilles vides à chaque poubelle ?
Données
Entrée

Ligne 1 : un entier V (≤ 10^9), le nombre de bouteilles que peut contenir chaque poubelle.

Ligne 2 : trois entiers A, B et C (≤ 10^9) correspondant aux nombres respectifs de bouteilles de jus d'Abricot, de Banane et de Carotte que vous devez jeter.
Sortie

Quatre entiers séparés par des espaces : les deux premiers correspondent respectivement aux nombres de bouteilles de jus d'Abricot et de Banane (dans cet ordre) que vous désirez jeter dans la poubelle bleue, les deux derniers correspondent respectivement aux nombres de bouteilles de jus de Banane et de Carotte (dans cet ordre) que vous désirez jeter dans la poubelle rouge.

On vous garantit qu'il y a toujours une solution possible. Si plusieurs solutions existent, il vous suffit de renvoyer n'importe laquelle.
Exemple

Pour l'entrée :

6
4 6 2

Une sortie possible est :

4 2 4 2

En effet, si vous disposez de 4 bouteilles de jus d'Abricot, 6 bouteilles de jus de Banane et 2 de jus de Carotte, vous pouvez placer vos 4 bouteilles de jus d'Abricot ainsi que 2 bouteilles de jus de Banane dans la poubelle bleue, puis les 4 bouteilles restantes de jus de Banane avec les 2 bouteilles de jus de Carotte dans la poubelle rouge.


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
            var capacity = int.Parse(Console.ReadLine());
            var bottles = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var answer = new int[4];
            answer[0]=bottles[0];
            answer[3]=bottles[2];
            answer[1]=Math.Min(bottles[1], capacity-bottles[0]); //we put as many banana bottles in the first bin as we can
            bottles[1]-=answer[1];
            answer[2]=bottles[1]; //we put the remaining banana bottles in the second bin
            
            Console.WriteLine(string.Join(" ", answer));
        }
    }
}
