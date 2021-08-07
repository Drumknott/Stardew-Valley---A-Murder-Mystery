using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stardew_Valley___A_Murder_Mystery
{
    class Intro
    {
        public void Opening()
        {
            Console.WriteLine("");
            Console.WriteLine("You're the only passenger on this bus. This place clearly doesn't get many visitors.");
            Console.WriteLine("As the bus speeds along you figure you'd better have a read of the case file. What was it your Chief said?");
            Console.WriteLine("Suspected murder, but this town doesn't have any police so you need to go and investigate it? Weird.");
            Console.WriteLine("You open the file.");
            Console.WriteLine("");
            Console.WriteLine("> Enter");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("CASE FILE #36284364");
            Console.WriteLine("");
            Console.WriteLine("Location:Pelican Town");
            Console.WriteLine("Time: Unknown");
            Console.WriteLine("");
            Console.WriteLine("911 call from town resident Marnie reporting the discovery of a dead body, reportedly that of the town Mayor Lewis.");
            Console.WriteLine("The body is being kept at the local Doctor's Surgery. Awaiting further investigation.");
            Console.WriteLine("");
            Console.WriteLine("> Enter");
            Console.ReadKey();
            Console.WriteLine("");
            Console.WriteLine("The bus driver, a woman with blonde hair, pulls the bus over and yells out 'Pelican Town!'");
            Console.WriteLine("As you disembark you thank her, but get a whiff of alcohol on her breath. Was she drink driving!?");
            Console.WriteLine("Before you can say anything she reaches out her hand.");
            Console.WriteLine("Pam > Hi, I'm Pam. Are you the detective who's come to see about Mayor Lewis?");
            Console.WriteLine("");
        }
    }
}
