using System;

namespace SVUS.CONSOLE.APP
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
            Logic.StudentLogic.OpChoice();

            Console.ReadLine();
        }
        static void Menu()
        {
            String menu;
            menu = String.Format(
                "==================================================\n " +
                "                     IZVELNE \n" +
                "==================================================\n " +
                "1. Pievienot jaunu studentu\n" +
                "2. Dzest studentu \n" +
                "3. Atjaunot  studenta datus \n" +
                "4. Apskatit visu studentu sarakstu \n" +
                "5. Izveidot parskatu par videjam studentu atzimem \n" +
                "6. Izveidot parskatu par studentu gala vertejumiem \n" +
                "7. Paradit datus par studentu (-iem), ar visaugstako(-ajiem) vertejumiem \n" +
                "8. Paradit datus par studentu (-iem), ar viszemako(-ajiem) vertejumiem \n" +
                "9. Atrast studentu pec ID \n" +
                "==================================================\n" +
                "Izvēlētā darbība: ");
            Console.Write(menu);
        }

    }
}
