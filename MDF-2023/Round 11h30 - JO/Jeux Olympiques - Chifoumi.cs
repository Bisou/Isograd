using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
Jeux Olympiques - Chifoumi

Les Jeux Olympiques de Paris s’approchent et la nouvelle discipline tant attendue Pierre-Feuille-Ciseau fait son entrée.

Le format est simple : les participants se placent sur une ligne, puis chaque participant choisit un coup qu’il va jouer. A chaque tour, le joueur le plus à gauche joue contre son voisin à Pierre-Feuille-Ciseau et le perdant sort de la ligne (en cas d'égalité, le joueur le plus à gauche gagne). Les tours s'enchaînent jusqu'à ce qu'il ne reste plus qu'un seul joueur.

Vous avez pu récupérer les coups de tous les joueurs, vous voulez savoir quel est le coup du gagnant.
Données
Entrée

Ligne 1 : Une chaine de caractères de longueur comprise entre 1 et 100 composée uniquement de caractères P pour pierre, F pour feuille, C pour ciseau.
Sortie

Un seul caractère : le coup du gagnant.
Exemple
Entrée

PFFCPC

Sortie

P

Explication, le déroulé de chaque tour :

    Le joueur de gauche joue P, son voisin F : ce dernier remporte la partie, les joueurs restants sont FFCPC
    Les deux joueurs jouent F, le joueur le plus a gauche perd. Il reste FCPC
    Au tour suivant, il restera CPC
    Au tour suivant, il restera PC

Le gagnant final aura donc joué P, c'est la réponse qu'il faudra renvoyer 
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
            var line = Console.ReadLine();
            var lastMove = line[0];
            
            for (var i=1; i<line.Length; ++i) {
                if (lastMove=='P' && line[i]=='F')
                    lastMove=line[i];
                else if (lastMove=='F' && line[i]=='C')
                    lastMove=line[i];
                else if (lastMove=='C' && line[i]=='P')
                    lastMove=line[i];
            }
            
            Console.WriteLine(lastMove);
        }
    }
}
