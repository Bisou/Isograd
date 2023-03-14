using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Classement à la main

Vous ne le savez peut-être pas, mais si on vous donne tous ces exercices à résoudre, c'est avant tout parce qu'on ne sait pas coder. Ainsi, après avoir chronométré à la main le temps de résolution de chaque exercice, et après avoir calculé (sur papier) un hash de chaque code soumis, c'est à la main que l'on élimine les candidats qui ont soumis un code avec le même hash qu'au moins un autre candidat. Enfin, c'est toujours à la main que l'on classe les participants restants par temps de résolution croissant.

Bon, vu la quantité de travail que ça demande, nous allons probablement faire ça avec un seul problème cette année. Et comme on aimerait bien profiter du buffet, disons que seuls les temps de résolution nous intéressent. Vous pouvez nous aider à classer les candidats ?
Données
Entrée

Ligne 1 : un entier N (1 ≤ N ≤ 100), le nombre de soumissions acceptées.

N lignes suivantes : une soumission représentée par un entier et une chaîne de caractères, séparés par des espaces. L'entier représente le temps de résolution de la soumission en minutes, et la chaîne de caractères (en minuscule sans espace) représente le hash de la soumission.
Sortie

Les temps de résolution des soumissions non-suspectes triés par temps croissant, un temps de résolution par ligne. Les solutions dont le hash apparaît dans plusieurs soumissions doivent être ignorés. On vous garantit qu'il y a au moins une soumission dont le hash est unique (ne serait-ce que parce qu'on vous fait confiance à vous).
Exemple

Pour l'entrée :

4
2 lessthanfourminutesiswaytoofast
30 shetookhertimebutdidnotcheat
59 waytooslow
3 lessthanfourminutesiswaytoofast

La sortie attendue est :

30
59

Même si deux candidats ont été très rapides (2 et 3 minutes), ils ont soumis le même code, ce qui les disqualifie. La soumission gagnante est donc celle qui a pris 30 minutes, suivie de celle en 59 minutes.


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
            var alreadySeen = new HashSet<string>();
            var validSubmissions = new List<(int Time, string Hash)>();
            string line;
            while ((line = Console.ReadLine()) != null) {
                var submission = line.Split(' ');
                if (alreadySeen.Contains(submission[1])) {
                    validSubmissions.RemoveAll(x => x.Hash==submission[1]);
                } else {
                    alreadySeen.Add(submission[1]);
                    validSubmissions.Add((int.Parse(submission[0]), submission[1]));
                }
            }
            
            Console.WriteLine(string.Join("\n", validSubmissions.Select(x => x.Time).OrderBy(time => time)));
        }
    }
}
