namespace C_Reg
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "C# Reg (Vertaald door: Ruben Anninga)"; // Application titel
            #region variables
            string keuze = "";
            string verderGaanString = "Maak uw keuze en druk op <ENTER>.\n";
            float bedragInKassaBegin = 0.0f;
            float dagTotaal = 0;
            int aantalBonnen = 0;
            float dagTotaalTerug = 0;
            #endregion
            Console.WriteLine("Welkom bij PyReg, het C-Sharp (C#) KassaSysteem voor en door DeveloperLand!" +
                              "Tel de kassa, en geef op hoeveel er nu in zit."); System.Threading.Thread.Sleep(1000);

            while (keuze == null)
            {
                Console.WriteLine("======== HOOFDMENU =========" +
                    "\n1. Nieuwe bon" +
                    "\n2. Retour" +
                    "\n3. Toon kassatotaal" +
                    "\n9. Afsluiten" +
                    "\n============================");

                Console.WriteLine(verderGaanString);
                keuze = Console.ReadLine();
            }

            while (keuze != "9")
            {
                if (int.TryParse(keuze, out _))
                {
                    if (keuze == "1")
                    {
                        int bestelKeuze = 0;
                        float bonTotaal = 0;
                        string bonString = "";
                        while (bestelKeuze.ToString() != "9")
                        {
                            Console.Write("========= BON MENU =========" +
                                $"\nBon {aantalBonnen.ToString()}" +
                                "\n1. Volwassene                     € 19,-" +
                                "\n2. Kinderen tot 12jr              € 9,-" +
                                "\n3. Familiepas (2x volw. 3x kind)  € 49" +
                                "\n4. DeveloperLand-kaart            € 4,50" +
                                "\n5. Kinderwagen/bolderkar (1 dag)  € 6" +
                                "\n6. Parkeerdagkaart                € 9" +
                                "\n9. Afronden bon" +
                                "\nZ. Bon annuleren" +
                                "============================");
                            Console.WriteLine(verderGaanString); bestelKeuze = Console.Read();

                            if (int.TryParse(bestelKeuze.ToString(), out _) || bestelKeuze.ToString().ToLower() == "z")
                            {
                                string keuzeSucccesvol = $"Keuze succesvol! Toegevoegd: {bonString}";
                                if (bestelKeuze == 1){
                                    bonTotaal += 19;
                                    bonString += "1x Volwassene                  € 19\r\ns";
                                }
                                else if (bestelKeuze == 2){
                                    bonTotaal += 19;
                                    bonString += "1x kind (tot 12jr)             € 9\r\n";
                                }
                                else if (bestelKeuze == 3){
                                    bonTotaal += 49;
                                    bonString += "1x Familiepas                  € 49\r\n";
                                }
                                else if (bestelKeuze == 4){
                                    bonTotaal += 4.50f;
                                    bonString += "1x Parkkaart                   € 4,50\r\n";
                                }
                                else if(bestelKeuze == 5){
                                    bonTotaal += 6;
                                    bonString += "1x kinderwagen/bolderkarhuur   € 6\r\n";
                                }
                                else if (bestelKeuze == 6) {
                                    bonTotaal += 9;
                                    bonString += "1x Parkeerdagkaart             € 9\r\n";
                                }
                                else if(bestelKeuze == 9) {
                                    aantalBonnen += 1;
                                    dagTotaal += bonTotaal;
                                    Console.WriteLine(bonString);
                                    Console.Write("======== BON TOTAAL ========\n" +
                                                 $"Te betalen: {bonTotaal.ToString()}");

                                    Console.WriteLine("Betaald:    "); float betaalt = float.Parse(Console.ReadLine());
                                    float terug = bonTotaal - betaalt;
                                    Console.WriteLine($"Terug:     {terug}" +
                                                      $"\n{verderGaanString}");
                                }
                                else if (bestelKeuze.ToString().ToLower() == "z") {
                                    bestelKeuze = 9;
                                    bonTotaal = 0;
                                    bonString = "";
                                }
                            }
                            else
                            {

                            }
                        }
                    }
                    else if(keuze == "2") {
                        Console.WriteLine("Uitvoeren terugbetaling" +
                                          "\nBedrag originele bon: ");
                        float terugTeGeven = float.Parse(Console.ReadLine());
                        Console.WriteLine("Reden retour: ");
                        string reden = Console.ReadLine();
                        dagTotaalTerug = terugTeGeven;
                    }
                    else if (keuze == "3") {
                        Console.Write("======= DAG TOTALEN ========" +
                                     $"In kassa begin:   {bedragInKassaBegin}" +
                                     $"Verkocht:         {dagTotaal}" +
                                     $"Retour:           {dagTotaalTerug}" +
                                     $"In kassa:         {((bedragInKassaBegin + dagTotaal) - dagTotaalTerug)}" +
                                     $"{verderGaanString}");
                        Console.ReadLine();
                    }
                }
                else
                {
                    keuze = null;
                }
            }
            float inKassa = float.Parse(Console.ReadLine());
            while (inKassa != ((bedragInKassaBegin + dagTotaal) - dagTotaalTerug)) {
                Console.WriteLine("Je hebt een kassaverschil! Tel de kassa opnieuw" +
                                  "\nHoeveel zit er nu in de kassa?");
                inKassa = float.Parse(Console.ReadLine());
            }

            Console.Clear();
            Console.WriteLine("Kassa klopt, programma wordt afgesloten." +
                              "\n======== DAGTOTALEN ========" +
                             $"\nAantal bonnen: {aantalBonnen}" +
                             $"\nVerkocht:      {dagTotaal}" +
                             $"\nTotaal retour: {dagTotaalTerug}" +
                             $"\nIn kassa:      {inKassa}" +
                              "============================");
        }
    }
}