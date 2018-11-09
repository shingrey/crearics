using System;

namespace crearics
{
    class Program
    {
        static void Main(string[] args)
        {
            Fechas f = new Fechas();
            Console.Write("Introduce email id (sirve para identificar)");
            string emailid = Console.ReadLine();
            Console.Write("\nNombre de organizador");
            string nombreorg = Console.ReadLine();
            Console.Write("\nEmail de organizador");
            string tuEmail = Console.ReadLine();


            Console.Write("\nAño inicio");
            int anoin = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nmes inicio");
            int mesin = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nDia inicio");
            int diain = Convert.ToInt16(Console.ReadLine());

            Console.Write("\nHora inicio 0-23");
            int horain = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nMinutos inicio 0-59");
            int minin = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nSegundos inicio 0-59");
            int segin = Convert.ToInt16(Console.ReadLine());
            
            Console.Write("\nAño fin");
            int anofin = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nmes fin");
            int mesfin = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nDia fin");
            int diafin = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nHora fin 0-23");
            int horafin = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nMin fin 0-59");
            int minfin = Convert.ToInt16(Console.ReadLine());
            Console.Write("\nSegundo fin 0-59");
            int segfin = Convert.ToInt16(Console.ReadLine());

            Console.Write("\nAsunto no max-60");
            string asunto = Console.ReadLine();
            
            CrearICS cr = new CrearICS();
            cr.CreameEsta(emailid, nombreorg, tuEmail, asunto, anoin, mesin, diain, horain, minin, segin, anofin, mesfin, diafin, horafin, minfin, segfin);
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
