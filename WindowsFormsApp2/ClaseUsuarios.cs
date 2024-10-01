using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace WindowsFormsApp2
{
    public class ClaseUsuarios
    {
        public static string ruta = Application.StartupPath + "\\Usuario.txt";
        //funcion que verifica si el archivo existe
        public static bool Func_ExisteTxt()
        {
            if (File.Exists(ruta))
            {
                return true;    
            }
            else
            { 
                return false; 
            }   
        }
        public static string[] Func_LeerArchivo()
        {
            string[] linea= File.ReadAllLines(ruta);
            return linea;
        }
        public static string[] Func_DatosUsuario(string user)
        {
            string[] usuario = null;
            string[] retorno = new string[2];
            string[] linea = Func_LeerArchivo();
            //recorro todas las lineas del txt
            for (int i = 0;i<linea.Length;i++) 
            {
                //split con comas
                usuario = linea[i].Split(',');
                // 0-ID. 1- USUARIO 2-PASS
                if (usuario[1] == user)
                {
                    //RETORNO USUARIO Y PASS
                    retorno[0] = user;
                    retorno[1] = usuario[2];
                    break;
                }
            }

            return retorno;
        }
        public static bool Func_EliminarUsuario(string id)
        {
            int lineaeliminar = 0;
            string[] usuario = null;
            string[] linea = Func_LeerArchivo();
            string[] retorno = new string[linea.Length-1];
            //recorro todas las lineas del txt
            for (int i = 0; i < linea.Length; i++)
            {
                //split con comas
                usuario = linea[i].Split(',');
                // 0-ID. 1- USUARIO 2-PASS
                if (usuario[0] == id)
                {
                    //elimino la linea
                    linea[i] = ",,";
                    break;
                }
            }
            int inc = 0;
            for (int j=0; j<linea.Length;j++)
            {
                //split con comas
                usuario = linea[j].Split(',');
                if (usuario[0] != "")
                {
                    //elimino la linea
                    retorno[inc] = linea[j];
                    inc++;
                }
            }

                return true;
        }
    }
}
