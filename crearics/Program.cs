using System;

namespace crearics
{
    class Program
    {
        static void Main(string[] args)
        {
            Fechas f = new Fechas();
            CrearICS cr = new CrearICS();
            cr.CreameEsta("cesar@unprogramador.com", "Cesar Flores", "cesarflores2205@gmail.com", "hola lesbiano", 2018, 10, 13, 12, 1, 0, 2018, 10, 14, 20, 23, 49);
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
        public void CreameEsta(string email, string nombreev, string emailor,string asunto,int ast, int mast, int dast, int hast, int mnast, int sast, int aed, int med, int ded, int hed, int mned, int sed)
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
UID:"+ email +
                            "\nDTSTAMP:" + f.Ahorawey() +
                            "\nORGANIZER; CN="+nombreev+":MAILTO:"+emailor +
                            "\nDTSTART:" + f.Regresameesta(ast, mast, dast, hast, mnast, sast) +
                            "\nDTEND:" + f.Regresameesta(aed, med, ded, hed, mned, sed) +

                            "\nSUMMARY:" + asunto+
                            "\nGEO:" + "25.6534664;-100.3407974"+
                            "\nEND:VEVENT" +
                            "\nEND:VCALENDAR";
                mylogs.WriteLine(ics);
                mylogs.Close();
            }
        }
    }
}
