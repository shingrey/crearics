using System;

namespace crearics
{
    class Program
    {
        static void Main(string[] args)
        {
            Fechas f = new Fechas();
            CrearICS cr = new CrearICS();
            cr.CreameEsta();
            Console.Write("------------------- \n");
            Console.Write("se creo archivo");
            Console.ReadKey();
        }
        
    }
    class Fechas
    {
        public String Regresameesta(int ano, int mes, int dia, int hora = 0, int minutos = 0, int segundo = 0)
        {
            DateTime dt2 = new DateTime(ano, mes, dia, hora, minutos, segundo);
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            DateTime dateTime;
            dateTime = TimeZoneInfo.ConvertTimeToUtc(dt2, TimeZoneInfo.Local);
            //regresar
            // dateTime2 = TimeZoneInfo.ConvertTime(dateTime, TimeZoneInfo.FindSystemTimeZoneById(localZone.StandardName));
            return dateTime.ToString("yyyyMMddTHHmmssZ");
        }
        public String Ahorawey()
        {
            DateTime dth = DateTime.Now;
            DateTime dTime;
            dTime = TimeZoneInfo.ConvertTimeToUtc(dth, TimeZoneInfo.Local);
            return dTime.ToString("yyyyMMddTHHmmssZ");
        }
    }
    class CrearICS
    {
        public void CreameEsta()
        {
            Fechas f = new Fechas();
            string lugar = @"C:\Users\ceflor\Documents\";
            System.IO.Directory.CreateDirectory(lugar);
            string nombre = "prueba" + DateTime.Now.ToString("ddMMyyyyss") + ".ics";
            lugar = System.IO.Path.Combine(lugar, nombre);
            /*using (System.IO.FileStream fs = System.IO.File.Create(lugar))
            {
                
                fs.Write


            }*/
            using (System.IO.StreamWriter mylogs = System.IO.File.AppendText(lugar))
            {
                String ics = @"BEGIN:VCALENDAR
VERSION:2.0
PRODID:-//hacksw/handcal//NONSGML v1.0//EN
BEGIN:VEVENT
UID:cesar@softwarerb.com
" + "DTSTAMP:" + f.Ahorawey() +
                            "\nORGANIZER; CN=Cesar Doe:MAILTO:cesar@unprogramador.com" +
                            "\nDTSTART:" + f.Regresameesta(2018, 10, 09, 12, 00, 00) +
                            "\nDTEND:" + f.Regresameesta(2018, 10, 09, 15, 30, 00) +
                            @"
SUMMARY:Callate viejo lesbiano
GEO:25.6534664;-100.3407974
END:VEVENT
END:VCALENDAR";
                mylogs.WriteLine(ics);
                mylogs.Close();
            }
        }
    }
}
