using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace TesteSqlite.Infrastructure
{
    public static class TesteSqliteConnectionString
    {
        public static string getConnectionString()
        {
            string Servidor, DBCartorio, Porta;
            string[] strings;
            RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(@"Software\CartSys\Backup\FIREBIRD", false);
            Servidor = registryKey.GetValue("Servidor").ToString();
            if (Servidor.Contains("/"))
            {
                strings = Servidor.Split(new char[] { '/' });
                Servidor = strings[0];
                Porta = strings[1];
            }
            else
            {
                Porta = "3050";
            }
            DBCartorio = registryKey.GetValue("DBCartorio").ToString();
            return String.Format("DataSource={0};Port={1};Database={2};User=SYSDBA;Password=masterkey;Charset=WIN1252 ", Servidor, Porta, DBCartorio);

        }
    }
}
