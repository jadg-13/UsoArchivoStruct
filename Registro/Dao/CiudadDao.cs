using Registro.Estructuras;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Registro.Dao
{
    internal class CiudadDao
    {
        private List<Ciudad> ciudades;

        public CiudadDao()
        {
            ciudades = new List<Ciudad>();
        }

        public void Agregar(Ciudad ciudad)
        {
            ciudades.Add(ciudad);
            GuardarArchivo();
        }

        public void Actualizar(Ciudad ciudad)
        {
            int index = ciudades.FindIndex(item => item.ID == ciudad.ID);

            if (index != -1)
            {
                ciudades[index] = ciudad;
            }
            GuardarArchivo();
        }

        public List<Ciudad> Listar()
        {
            ciudades.Clear();
            CargarArchivo();
            return ciudades;
        }

        public void SetList(List<Ciudad> list)
        {
            ciudades = list;
        }

        public Ciudad Buscar(int id)
        {
            return ciudades.Find(item => item.ID == id);
        }

        public int BuscarIndex(int id)
        {
            return ciudades.FindIndex(item => item.ID == id);
        }

        public void Eliminar(Ciudad ciudad)
        {
            ciudades.Remove(ciudad);
            GuardarArchivo();
        }

        public void Ordenar()
        {
            ciudades.Sort((x, y) => x.Nombre.CompareTo(y.Nombre));
        }

        private void GuardarArchivo()
        {
            string rutaArchivo = "ciudades.dat";
            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Create, FileAccess.Write))
            {
                using (BinaryWriter escritor = new BinaryWriter(archivo))
                {
                    foreach (Ciudad c in ciudades)
                    {
                        escritor.Write(c.ID);
                        escritor.Write(c.Nombre.Length);
                        escritor.Write(c.Nombre.ToCharArray());
                        escritor.Write(c.Poblacion);
                    }
                }
            }
        }

        private void CargarArchivo()
        {
            string rutaArchivo = "ciudades.dat";
            if (!File.Exists(rutaArchivo))
            {
                return;
            }

            using (FileStream archivo = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read))
            {
                using (BinaryReader lector = new BinaryReader(archivo))
                {
                    while (archivo.Position != archivo.Length)
                    {
                        int id = lector.ReadInt32();
                        int tamaño = lector.ReadInt32();
                        char[] nombreArray = lector.ReadChars(tamaño);
                        string nombre = new string(nombreArray);
                        int poblacion = lector.ReadInt32();

                        Ciudad ciudad = new Ciudad();
                        ciudad.ID = id;
                        ciudad.Nombre = nombre;
                        ciudad.Poblacion = poblacion;
                        ciudades.Add(ciudad);
                    }
                }
            }
        }

    }
}
